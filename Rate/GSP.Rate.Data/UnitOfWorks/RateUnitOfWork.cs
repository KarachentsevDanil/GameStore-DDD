using GSP.Rate.Data.Context;
using GSP.Rate.Data.Repositories;
using GSP.Rate.Domain.Repositories;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Data.Account.UnitOfWorks;
using MediatR;

namespace GSP.Rate.Data.UnitOfWorks
{
    public class RateUnitOfWork : AccountUnitOfWork<RateDbContext>, IRateUnitOfWork
    {
        private IRateRepository _rateRepository;

        public RateUnitOfWork(RateDbContext context, IMediator mediator)
            : base(context, mediator)
        {
        }

        public IRateRepository RateRepository
        {
            get { return _rateRepository ??= new RateRepository(Context); }
        }
    }
}