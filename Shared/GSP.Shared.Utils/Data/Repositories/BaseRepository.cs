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
        private readonly DbSet<TEntity> _set;

        public BaseRepository(TContext context)
        {
            _set = context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(long id, CancellationToken ct)
        {
            return await _set.FindAsync(id, ct);
        }

        public async Task<ICollection<TEntity>> GetListAsync(CancellationToken ct)
        {
            return await _set.AsNoTracking().ToListAsync(ct);
        }

        public TEntity Create(TEntity entity)
        {
            _set.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _set.Update(entity);
            return entity;
        }

        public void Delete(long id)
        {
            TEntity entity = _set.Find(id);
            _set.Remove(entity);
        }
    }
}