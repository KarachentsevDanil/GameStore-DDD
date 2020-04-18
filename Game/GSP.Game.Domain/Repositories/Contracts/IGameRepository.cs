using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Models.FilterParams;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Domain.Repositories.Contracts
{
    public interface IGameRepository : IBaseRepository<GameBase>
    {
        Task<ICollection<GameBase>> GetByIdsAsync(IEnumerable<long> ids, CancellationToken ct);

        Task<PagedCollection<GameBase>> GetByFilterParamsAsync(GameFilterParams filterParams, CancellationToken ct);
    }
}