using GSP.Shared.Utils.Domain.Base;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.Repositories
{
    public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        public BaseRepository(TContext context)
        {
            Set = context.Set<TEntity>();
        }

        protected DbSet<TEntity> Set { get; }

        public async Task<TEntity> GetAsync(long id, CancellationToken ct)
        {
            return await Set.FindAsync(id, ct);
        }

        public async Task<ICollection<TEntity>> GetListAsync(CancellationToken ct)
        {
            return await Set.AsNoTracking().ToListAsync(ct);
        }

        public TEntity Create(TEntity entity)
        {
            Set.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Set.Update(entity);
            return entity;
        }

        public void Delete(long id)
        {
            TEntity entity = Set.Find(id);
            Set.Remove(entity);
        }
    }
}