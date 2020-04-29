using GSP.Recommendation.Domain.Entities;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<CompletedOrder>
    {
        Task<IEnumerable<long>> GetAccountGameIdsAsync(long accountId, CancellationToken ct);
    }
}