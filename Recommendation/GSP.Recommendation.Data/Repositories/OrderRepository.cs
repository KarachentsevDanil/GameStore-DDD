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

        public async Task<ICollection<ICollection<OrderGame>>> GetGameTransactionsByAccountAsync(long accountId, long gameId, CancellationToken ct)
        {
            var query = await DbSet
                .Include(i => i.Games)
                .Where(q => q.AccountId == accountId)
                .SelectMany(p => p.Games)
                .ToListAsync(ct);

            var accountGames = query.Select(t => t.GameId).ToList();

            if (accountGames.Contains(gameId))
            {
                return Enumerable.Empty<ICollection<OrderGame>>().ToList();
            }

            var transactionQuery = await DbSet
                .Include(i => i.Games)
                .Where(q => q.Games.Any(g => g.GameId == gameId) && q.Games.All(g => !accountGames.Contains(g.GameId)))
                .Select(s => s.Games)
                .ToListAsync(ct);

            return transactionQuery;
        }

        public async Task<ICollection<ICollection<OrderGame>>> GetGameTransactionsByGameAsync(long gameId, CancellationToken ct)
        {
            var transactionQuery = await DbSet
                .Include(i => i.Games)
                .Where(q => q.Games.Any(g => g.GameId == gameId))
                .Select(s => s.Games)
                .ToListAsync(ct);

            return transactionQuery;
        }
    }
}