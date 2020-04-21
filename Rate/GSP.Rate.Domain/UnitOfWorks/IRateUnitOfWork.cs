using GSP.Rate.Domain.Repositories;
using GSP.Shared.Utils.Domain.Account.UnitOfWorks.Contracts;

namespace GSP.Rate.Domain.UnitOfWorks
{
    public interface IRateUnitOfWork : IAccountUnitOfWork
    {
        IRateRepository RateRepository { get; }
    }
}