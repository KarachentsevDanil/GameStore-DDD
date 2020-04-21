using GSP.Rate.Domain.Repositories;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;

namespace GSP.Rate.Domain.UnitOfWorks
{
    public interface IRateUnitOfWork : IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }

        IRateRepository RateRepository { get; }
    }
}