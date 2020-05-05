using GSP.Payment.Domain.Entities;
using GSP.Payment.Domain.Models;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Domain.Repositories.Contracts
{
    public interface IPaymentHistoryRepository : IBaseRepository<PaymentHistory>
    {
        ValueTask<bool> IsExistsAsync(long accountId, long orderId, CancellationToken ct);

        Task<PagedCollection<PaymentHistory>> GetListByAccountIdAsync(PaymentHistoryFilterParams filterParams, CancellationToken ct);
    }
}