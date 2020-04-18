using GSP.Game.Data.Context;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Data.Repositories;

namespace GSP.Game.Data.Repositories
{
    public class PublisherRepository : BaseRepository<GameDbContext, Publisher>, IPublisherRepository
    {
        public PublisherRepository(GameDbContext context)
            : base(context)
        {
        }
    }
}