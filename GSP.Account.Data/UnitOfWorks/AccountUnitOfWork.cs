using GSP.Account.Data.Context;
using GSP.Account.Data.Repositories;
using GSP.Account.Domain.Repositories.Contracts;
using GSP.Account.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Data.UnitOfWorks;
using MediatR;

namespace GSP.Account.Data.UnitOfWorks
{
    public class AccountUnitOfWork : UnitOfWork<AccountDbContext>, IAccountUnitOfWork
    {
        private readonly AccountDbContext _context;

        private IAccountRepository _accountRepository;

        public AccountUnitOfWork(AccountDbContext context, IMediator mediator)
            : base(context, mediator)
        {
            _context = context;
        }

        public IAccountRepository AccountRepository
        {
            get { return _accountRepository ??= new AccountRepository(_context); }
        }
    }
}