using GSP.Recommendation.Data.Context;
using GSP.Recommendation.Domain.Entities;
using GSP.Recommendation.Domain.Repositories;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Data.Repositories
{
    public class OrderRepository : BaseRepository<RecommendationDbContext, CompletedOrder>, IOrderRepository
    {
        public OrderRepository(RecommendationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<long>> GetAccountGameIdsAsync(long accountId, CancellationToken ct)
        {
            var accountGames = await DbSet
                .Include(i => i.Games)
                .Where(q => q.AccountId == accountId)
                .SelectMany(p => p.Games)
                .ToListAsync(ct);

            return accountGames.Select(t => t.GameId).ToList();
        }
    }
}