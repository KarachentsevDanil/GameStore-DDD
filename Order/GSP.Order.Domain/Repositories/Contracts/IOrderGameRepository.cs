using GSP.Order.Domain.Entities;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Domain.Repositories.Contracts
{
    public interface IOrderGameRepository : IBaseRepository<OrderGame>
    {
        Task<ICollection<OrderGame>> GetListByAccountId(long accountId, CancellationToken ct);

        Task<bool> IsExists(long accountId, long gameId, CancellationToken ct);

        ValueTask<int> GetOrderCountByGameIdAsync(long gameId, CancellationToken ct);
    }
}