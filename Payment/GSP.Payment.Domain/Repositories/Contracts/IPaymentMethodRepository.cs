using GSP.Payment.Domain.Entities;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Domain.Repositories.Contracts
{
    public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
    {
        Task<ICollection<PaymentMethod>> GetListByAccountIdAsync(long accountId, CancellationToken ct);
    }
}