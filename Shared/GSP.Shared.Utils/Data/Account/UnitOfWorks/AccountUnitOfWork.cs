using GSP.Shared.Utils.Data.Account.Repositories;
using GSP.Shared.Utils.Data.UnitOfWorks;
using GSP.Shared.Utils.Domain.Account.Repositories.Contracts;
using GSP.Shared.Utils.Domain.Account.UnitOfWorks.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GSP.Shared.Utils.Data.Account.UnitOfWorks
{
    public abstract class AccountUnitOfWork<TContext> : UnitOfWork<TContext>, IAccountUnitOfWork
        where TContext : DbContext
    {
        private IAccountRepository _accountRepository;

        protected AccountUnitOfWork(TContext context, IMediator mediator)
            : base(context, mediator)
        {
        }

        public IAccountRepository AccountRepository
        {
            get { return _accountRepository ??= new AccountRepository<TContext>(Context); }
        }
    }
}