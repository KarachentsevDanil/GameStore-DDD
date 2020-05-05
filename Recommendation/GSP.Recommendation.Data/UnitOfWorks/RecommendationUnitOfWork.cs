using GSP.Recommendation.Data.Context;
using GSP.Recommendation.Data.Repositories;
using GSP.Recommendation.Domain.Repositories;
using GSP.Recommendation.Domain.UnitOfWorks;
using GSP.Shared.Utils.Common.UserPrincipal.Contracts;
using GSP.Shared.Utils.Data.UnitOfWorks;
using MediatR;

namespace GSP.Recommendation.Data.UnitOfWorks
{
    public class RecommendationUnitOfWork : UnitOfWork<RecommendationDbContext>, IRecommendationUnitOfWork
    {
        private IGameRepository _gameRepository;

        private IOrderRepository _orderRepository;

        public RecommendationUnitOfWork(RecommendationDbContext context, IMediator mediator, IGspUserPrincipal gspUserPrincipal)
            : base(context, mediator, gspUserPrincipal)
        {
        }

        public IGameRepository GameRepository
        {
            get { return _gameRepository ??= new GameRepository(Context); }
        }

        public IOrderRepository OrderRepository
        {
            get { return _orderRepository ??= new OrderRepository(Context); }
        }
    }
}