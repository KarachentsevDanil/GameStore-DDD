using System.Collections.Generic;
using System.Collections.Immutable;
using GSP.Recommendation.Domain.Entities;
using GSP.Recommendation.Domain.Models;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Domain.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<PagedCollection<Game>> GetByFilterParamsAsync(GameFilterParams filterParams, CancellationToken ct);

        Task<ICollection<Game>> GetAvailableGamesForAccountAsync(IEnumerable<long> accountGameIds, CancellationToken ct);
    }
}