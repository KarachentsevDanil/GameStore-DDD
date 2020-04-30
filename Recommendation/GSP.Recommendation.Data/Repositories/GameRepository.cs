using GSP.Recommendation.Data.Context;
using GSP.Recommendation.Domain.Entities;
using GSP.Recommendation.Domain.Enums;
using GSP.Recommendation.Domain.Models;
using GSP.Recommendation.Domain.Repositories;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Data.Repositories
{
    public class GameRepository : BaseRepository<RecommendationDbContext, Game>, IGameRepository
    {
        public GameRepository(RecommendationDbContext context)
            : base(context)
        {
        }

        public async Task<PagedCollection<Game>> GetByFilterParamsAsync(GameFilterParams filterParams, CancellationToken ct)
        {
            var query = DbSet.AsNoTracking();

            SortGames(filterParams.SortingType, query);

            query = GetPagedQuery(query, filterParams, out int totalCount);

            var result = await query.ToListAsync(ct);

            return new PagedCollection<Game>(result, totalCount);
        }

        private void SortGames(GameSortingType sortingType, IQueryable<Game> query)
        {
            switch (sortingType)
            {
                case GameSortingType.CountOfOrders:
                    query = query.OrderByDescending(p => p.CountOfOrders);
                    break;
                case GameSortingType.CountOfReviews:
                    query = query.OrderByDescending(p => p.CountOfReviews);
                    break;
                case GameSortingType.AverageRating:
                    query = query.OrderByDescending(p => p.AverageRating);
                    break;
            }
        }
    }
}