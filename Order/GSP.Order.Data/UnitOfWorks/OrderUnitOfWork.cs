using GSP.Order.Data.Context;
using GSP.Order.Data.Repositories;
using GSP.Order.Domain.Repositories.Contracts;
using GSP.Order.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Common.UserPrincipal.Contracts;
using GSP.Shared.Utils.Data.Account.UnitOfWorks;
using MediatR;

namespace GSP.Order.Data.UnitOfWorks
{
    public class OrderUnitOfWork : AccountUnitOfWork<OrderDbContext>, IOrderUnitOfWork
    {
        private IGameRepository _gameRepository;

        private IOrderGameRepository _orderGameRepository;

        private IOrderRepository _orderRepository;

        public OrderUnitOfWork(OrderDbContext context, IMediator mediator, IGspUserPrincipal gspUserPrincipal)
            : base(context, mediator, gspUserPrincipal)
        {
        }

        public IGameRepository GameRepository
        {
            get { return _gameRepository ??=new GameRepository(Context); }
        }

        public IOrderGameRepository OrderGameRepository
        {
            get { return _orderGameRepository ??= new OrderGameRepository(Context); }
        }

        public IOrderRepository OrderRepository
        {
            get { return _orderRepository ??= new OrderRepository(Context); }
        }
    }
}