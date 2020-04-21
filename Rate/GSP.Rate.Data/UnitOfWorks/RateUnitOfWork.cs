using GSP.Rate.Data.Context;
using GSP.Rate.Data.Repositories;
using GSP.Rate.Domain.Repositories;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Data.UnitOfWorks;
using MediatR;

namespace GSP.Rate.Data.UnitOfWorks
{
    public class RateUnitOfWork : UnitOfWork<RateDbContext>, IRateUnitOfWork
    {
        private IAccountRepository _accountRepository;

        private IRateRepository _rateRepository;

        public RateUnitOfWork(RateDbContext context, IMediator mediator)
            : base(context, mediator)
        {
        }

        public IAccountRepository AccountRepository
        {
            get { return _accountRepository ??= new AccountRepository(Context); }
        }

        public IRateRepository RateRepository
        {
            get { return _rateRepository ??= new RateRepository(Context); }
        }
    }
}