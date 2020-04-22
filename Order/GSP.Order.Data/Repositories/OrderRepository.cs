using GSP.Order.Data.Context;
using GSP.Order.Domain.Entities;
using GSP.Order.Domain.Enums;
using GSP.Order.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Data.Repositories
{
    public class OrderRepository : BaseRepository<OrderDbContext, OrderBase>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context)
            : base(context)
        {
        }

        public async Task<OrderBase> GetCurrentOrderAsync(long accountId, CancellationToken ct)
        {
            return await DbSet
                .Include(p => p.Account)
                .Include(p => p.Games)
                    .ThenInclude(p => p.Game)
                .SingleOrDefaultAsync(q => q.AccountId == accountId && q.OrderStatus == OrderStatus.New, ct);
        }

        public async Task<ICollection<OrderBase>> GetListByAccountId(long accountId, CancellationToken ct)
        {
            return await DbSet
                .Include(p => p.Account)
                .Include(p => p.Games)
                    .ThenInclude(p => p.Game)
                .Where(q => q.AccountId == accountId)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}