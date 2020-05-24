﻿using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using GSP.Shared.Utils.Common.Models.Grids;
using GSP.Shared.Utils.Domain.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Domain.Repositories.Contracts
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(long id, CancellationToken ct);

        Task<ICollection<TEntity>> GetListAsync(CancellationToken ct);

        Task<bool> IsExistsAsync(long id, CancellationToken ct);

        Task<PagedCollection<TEntity>> GetPagedListAsync(PaginationFilterParams filterParams, CancellationToken ct);

        Task<GridModel> GetPagedListAsync(ILinqGrid<TEntity> grid, CancellationToken ct);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(long id);
    }
}