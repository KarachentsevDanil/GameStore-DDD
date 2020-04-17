﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GSP.Shared.Utils.Domain.Base;

namespace GSP.Shared.Utils.Domain.Repositories.Contracts
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(long id, CancellationToken ct);

        Task<ICollection<TEntity>> GetListAsync(CancellationToken ct);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(long id);
    }
}