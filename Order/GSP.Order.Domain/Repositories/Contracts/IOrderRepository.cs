using GSP.Order.Domain.Entities;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Domain.Repositories.Contracts
{
    public interface IOrderRepository : IBaseRepository<OrderBase>
    {
        Task<OrderBase> GetCurrentOrderAsync(long accountId, CancellationToken ct);

        Task<ICollection<OrderBase>> GetListByAccountId(long accountId, CancellationToken ct);
    }
}