using GSP.Order.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Domain.Account.UnitOfWorks.Contracts;

namespace GSP.Order.Domain.UnitOfWorks.Contracts
{
    public interface IOrderUnitOfWork : IAccountUnitOfWork
    {
        IGameRepository GameRepository { get; }

        IOrderRepository OrderRepository { get; }
    }
}