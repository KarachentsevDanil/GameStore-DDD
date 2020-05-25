﻿using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using GSP.Shared.Utils.Common.Models.Grids;
using GSP.Shared.Utils.Common.Models.Grids.Summaries;
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

        public virtual async Task<GridModel> GetPagedListAsync(IGrid<TEntity> grid, CancellationToken ct)
        {
            var query = DbSet
                .AsNoTracking()
                .AsQueryable()
                .Include(grid.IncludeEntities)
                .Where(grid.GetFiltersExpression());

            int totalCount = await query.CountAsync(ct);
            var summaries = GetGridSummaries(grid, query);

            var items = await query
                .Ordered(grid.GetSortedSortingOptions())
                .Skip(grid.Pagination.PageSize * (grid.Pagination.PageNumber - 1))
                .Take(grid.Pagination.PageSize)
                .ToListAsync(ct);

            var gridGroups = grid.GetGroupNames();
            if (gridGroups.Any())
            {
                var groupedItems = items.GroupByDynamic(gridGroups);
                return new GridModel(summaries, groupedItems.ToImmutableList(), totalCount);
            }

            return new GridModel(summaries, items.Cast<dynamic>().ToImmutableList(), totalCount);
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

        protected virtual ICollection<GridSummaryModel> GetGridSummaries(IGrid<TEntity> grid, IQueryable<TEntity> query)
        {
            var gridColumns = new List<GridSummaryModel>();

            foreach (var summary in grid.Summaries)
            {
                object value = query.SummaryDynamic(summary.PropertyName, summary.Type);
                var summaryModel = new GridSummaryModel(summary.PropertyName, summary.Type, value);
                gridColumns.Add(summaryModel);
            }

            return gridColumns;
        }
    }
}