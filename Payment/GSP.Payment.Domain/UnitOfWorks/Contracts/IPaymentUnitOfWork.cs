using GSP.Payment.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;

namespace GSP.Payment.Domain.UnitOfWorks.Contracts
{
    public interface IPaymentUnitOfWork : IUnitOfWork
    {
        IPaymentHistoryRepository PaymentHistoryRepository { get; }

        IPaymentMethodRepository PaymentMethodRepository { get; }
    }
}