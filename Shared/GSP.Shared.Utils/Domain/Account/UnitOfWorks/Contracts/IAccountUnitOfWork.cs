using GSP.Shared.Utils.Domain.Account.Repositories.Contracts;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;

namespace GSP.Shared.Utils.Domain.Account.UnitOfWorks.Contracts
{
    public interface IAccountUnitOfWork : IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
    }
}