using GSP.Order.Data.Context;
using GSP.Order.Domain.Entities;
using GSP.Order.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Data.Repositories;

namespace GSP.Order.Data.Repositories
{
    public class GameRepository : BaseRepository<OrderDbContext, Game>, IGameRepository
    {
        public GameRepository(OrderDbContext context)
            : base(context)
        {
        }
    }
}