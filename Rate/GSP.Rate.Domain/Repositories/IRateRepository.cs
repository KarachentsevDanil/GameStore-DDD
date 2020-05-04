using GSP.Rate.Domain.Entities;
using GSP.Rate.Domain.Models;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Domain.Repositories
{
    public interface IRateRepository : IBaseRepository<RateBase>
    {
        Task<PagedCollection<RateBase>> GetByFilterParamsAsync(RateFilterParams filterParams, CancellationToken ct);

        ValueTask<bool> IsExistsAsync(long accountId, long gameId, CancellationToken ct);

        ValueTask<int> GetCountByGameIdAsync(long gameId, CancellationToken ct);

        ValueTask<double> GetAverageRatingByGameIdAsync(long gameId, CancellationToken ct);
    }
}