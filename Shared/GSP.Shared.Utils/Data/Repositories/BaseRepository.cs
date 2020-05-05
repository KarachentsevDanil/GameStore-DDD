using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using GSP.Shared.Utils.Data.Context;
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

            int totalCount = query.Count();

            var items = await query
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .AsNoTracking()
                .ToListAsync(ct);

            return new PagedCollection<TEntity>(items.ToImmutableList(), totalCount);
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

        protected IQueryable<TEntity> GetPagedQuery(IQueryable<TEntity> query, PaginationFilterParams filterParams, out int totalCount)
        {
            totalCount = query.Count();

            var items = query
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize);

            return items;
        }
    }
}