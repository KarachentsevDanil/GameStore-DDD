using GSP.Recommendation.Domain.Repositories;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;

namespace GSP.Recommendation.Domain.UnitOfWorks
{
    public interface IRecommendationUnitOfWork : IUnitOfWork
    {
        IGameRepository GameRepository { get; }

        IOrderRepository OrderRepository { get; }
    }
}