using GSP.Order.Data.Context;
using GSP.Order.Domain.Entities;
using GSP.Order.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Data.Repositories
{
    public class OrderGameRepository : BaseRepository<OrderDbContext, OrderGame>, IOrderGameRepository
    {
        public OrderGameRepository(OrderDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<OrderGame>> GetListByAccountId(long accountId, CancellationToken ct)
        {
            return await DbSet
                .Include(p => p.Game)
                .Include(p => p.Order)
                .Where(q => q.Order.AccountId == accountId)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<bool> IsExists(long accountId, long gameId, CancellationToken ct)
        {
            return await DbSet
                .Include(p => p.Order)
                .AsNoTracking()
                .AnyAsync(q => q.GameId == gameId && q.Order.AccountId == accountId, ct);
        }

        public async ValueTask<int> GetOrderCountByGameIdAsync(long gameId, CancellationToken ct)
        {
            return await DbSet.AsNoTracking().CountAsync(t => t.GameId == gameId, ct);
        }
    }
}