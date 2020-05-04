using GSP.Rate.Data.Context;
using GSP.Rate.Domain.Entities;
using GSP.Rate.Domain.Models;
using GSP.Rate.Domain.Repositories;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Data.Repositories
{
    public class RateRepository : BaseRepository<RateDbContext, RateBase>, IRateRepository
    {
        public RateRepository(RateDbContext context)
            : base(context)
        {
        }

        public async Task<PagedCollection<RateBase>> GetByFilterParamsAsync(RateFilterParams filterParams, CancellationToken ct)
        {
            var query = DbSet.Where(q => q.GameId == filterParams.GameId)
                .Include(t => t.Account)
                .OrderByDescending(q => q.CreatedAt)
                .AsNoTracking()
                .AsQueryable();

            int totalCount = await query.CountAsync(ct);

            var rates = await query
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .ToListAsync(ct);

            return new PagedCollection<RateBase>(rates.ToImmutableList(), totalCount);
        }

        public async ValueTask<bool> IsExistsAsync(long accountId, long gameId, CancellationToken ct)
        {
            return await DbSet.AnyAsync(q => q.GameId == gameId && q.AccountId == accountId, ct);
        }

        public async ValueTask<int> GetCountByGameIdAsync(long gameId, CancellationToken ct)
        {
            return await DbSet.CountAsync(q => q.GameId == gameId, ct);
        }

        public async ValueTask<double> GetAverageRatingByGameIdAsync(long gameId, CancellationToken ct)
        {
            var countOfReviews = await GetCountByGameIdAsync(gameId, ct);
            var sumOfReviews = await DbSet.Where(q => q.GameId == gameId).SumAsync(q => q.Rating, ct);
            return sumOfReviews / countOfReviews;
        }
    }
}