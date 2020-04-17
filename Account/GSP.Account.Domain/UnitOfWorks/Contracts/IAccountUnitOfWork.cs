using GSP.Account.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;

namespace GSP.Account.Domain.UnitOfWorks.Contracts
{
    public interface IAccountUnitOfWork : IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
    }
}