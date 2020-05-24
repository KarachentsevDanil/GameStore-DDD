using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using GSP.Shared.Utils.Common.Models.Grids;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Extensions;
using GSP.Shared.Utils.Domain.Base;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.Repositories
{
    public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : GspDbContext
    {
        public BaseRepository(TContext context)
        {
            DbSet = context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; }

        public virtual async Task<TEntity> GetAsync(long id, CancellationToken ct)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public virtual async Task<ICollection<TEntity>> GetListAsync(CancellationToken ct)
        {
            return await DbSet.AsNoTracking().ToListAsync(ct);
        }

        public virtual Task<bool> IsExistsAsync(long id, CancellationToken ct)
        {
            return DbSet.AnyAsync(t => t.Id == id, ct);
        }

        public virtual async Task<PagedCollection<TEntity>> GetPagedListAsync(PaginationFilterParams filterParams, CancellationToken ct)
        {
            var query = DbSet.AsNoTracking().AsQueryable();

            int totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .AsNoTracking()
                .ToListAsync(ct);

            return new PagedCollection<TEntity>(items.ToImmutableList(), totalCount);
        }

        public virtual async Task<GridModel> GetPagedListAsync(ILinqGrid<TEntity> grid, CancellationToken ct)
        {
            var query = DbSet.AsNoTracking().AsQueryable();

            foreach (var include in grid.IncludeEntities)
            {
                query = query.Include(include);
            }

            var expression = grid.GetGridFiltersLinqExpression();

            query = query.Where(expression);

            int totalCount = await query.CountAsync(ct);
            var columnsWithTotal = GetColumnsWithTotal(grid, query);

            var items = await query
                .Ordered(grid.GetSortingOptions())
                .Skip(grid.Pagination.PageSize * (grid.Pagination.PageNumber - 1))
                .Take(grid.Pagination.PageSize)
                .AsNoTracking()
                .ToListAsync(ct);

            var gridGroups = grid.GetGroups();
            if (gridGroups.Any())
            {
                var groupedItems = items.GroupByDynamic(gridGroups);
                return new GridModel(columnsWithTotal, groupedItems.ToImmutableList(), totalCount);
            }

            return new GridModel(columnsWithTotal, items.Cast<dynamic>().ToImmutableList(), totalCount);
        }

        public virtual TEntity Create(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public virtual void Delete(long id)
        {
            TEntity entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        protected virtual IQueryable<TEntity> GetPagedQuery(IQueryable<TEntity> query, PaginationFilterParams filterParams, out int totalCount)
        {
            totalCount = query.Count();

            var items = query
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize);

            return items;
        }

        protected virtual ICollection<GridColumnModel> GetColumnsWithTotal(ILinqGrid<TEntity> grid, IQueryable<TEntity> query)
        {
            var gridColumns = new List<GridColumnModel>();

            foreach (var column in grid.Columns.Where(q => q.IsCalculateTotalNeeded))
            {
                object total = query.SumDynamic(column.PropertyName);
                var columnWithTotal = new GridColumnModel(column.PropertyName, total);
                gridColumns.Add(columnWithTotal);
            }

            return gridColumns;
        }
    }
}