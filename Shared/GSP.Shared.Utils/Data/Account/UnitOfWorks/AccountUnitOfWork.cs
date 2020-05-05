using GSP.Shared.Utils.Common.UserPrincipal.Contracts;
using GSP.Shared.Utils.Data.Account.Repositories;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.UnitOfWorks;
using GSP.Shared.Utils.Domain.Account.Repositories.Contracts;
using GSP.Shared.Utils.Domain.Account.UnitOfWorks.Contracts;
using MediatR;

namespace GSP.Shared.Utils.Data.Account.UnitOfWorks
{
    public abstract class AccountUnitOfWork<TContext> : UnitOfWork<TContext>, IAccountUnitOfWork
        where TContext : GspDbContext
    {
        private IAccountRepository _accountRepository;

        protected AccountUnitOfWork(TContext context, IMediator mediator, IGspUserPrincipal gspUserPrincipal)
            : base(context, mediator, gspUserPrincipal)
        {
        }

        public IAccountRepository AccountRepository
        {
            get { return _accountRepository ??= new AccountRepository<TContext>(Context); }
        }
    }
}