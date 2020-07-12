using GSP.Shared.Grid.Expressions.Contracts;
using GSP.Shared.Grid.Grids;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Extensions;
using GSP.Shared.Utils.Data.Grid.Extensions;
using GSP.Shared.Utils.Data.Grid.Models;
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

        public virtual async Task<GridModel> GetPagedListAsync(IGridExpressionGenerator<TEntity> gridExpressionGenerator, BaseGrid<TEntity> grid, CancellationToken ct)
        {
            var query = DbSet
                .AsNoTracking()
                .AsQueryable()
                .IncludeMany(grid.GetIncludedEntities())
                .Where(gridExpressionGenerator.GetGridExpression(grid))
                .Ordered(grid.GetSortedSortingOptions());

            int totalCount = await query.CountAsync(ct);
            var summaries = grid.GetGridSummaries(query);

            query = query
                .Skip(grid.Pagination.PageSize * (grid.Pagination.PageNumber - 1))
                .Take(grid.Pagination.PageSize);

            var items = await query.ToListAsync(ct);

            if (!grid.IsGroupable)
            {
                return new GridModel(summaries, items.Cast<dynamic>().ToImmutableList(), totalCount);
            }

            return grid.GetGroupedGridItems(items, summaries, totalCount);
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
    }
}