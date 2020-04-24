using GSP.Payment.Data.Context;
using GSP.Payment.Data.Repositories;
using GSP.Payment.Domain.Repositories.Contracts;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Data.UnitOfWorks;
using MediatR;

namespace GSP.Payment.Data.UnitOfWorks
{
    public class PaymentUnitOfWork : UnitOfWork<PaymentDbContext>, IPaymentUnitOfWork
    {
        private IPaymentMethodRepository _paymentMethodRepository;

        private IPaymentHistoryRepository _paymentHistoryRepository;

        public PaymentUnitOfWork(PaymentDbContext context, IMediator mediator)
            : base(context, mediator)
        {
        }

        public IPaymentHistoryRepository PaymentHistoryRepository
        {
            get { return _paymentHistoryRepository ??= new PaymentHistoryRepository(Context); }
        }

        public IPaymentMethodRepository PaymentMethodRepository
        {
            get { return _paymentMethodRepository ??= new PaymentMethodRepository(Context); }
        }
    }
}