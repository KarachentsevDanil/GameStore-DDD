using GSP.Payment.Data.Context;
using GSP.Payment.Domain.Entities;
using GSP.Payment.Domain.Models;
using GSP.Payment.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Data.Repositories
{
    public class PaymentHistoryRepository : BaseRepository<PaymentDbContext, PaymentHistory>, IPaymentHistoryRepository
    {
        public PaymentHistoryRepository(PaymentDbContext context)
            : base(context)
        {
        }

        public async Task<PagedCollection<PaymentHistory>> GetListByAccountIdAsync(PaymentHistoryFilterParams filterParams, CancellationToken ct)
        {
            var query = DbSet.AsNoTracking().AsQueryable();

            int totalCount = query.Count();

            var items = await query
                .Where(q => q.AccountId == filterParams.AccountId)
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .AsNoTracking()
                .ToListAsync(ct);

            return new PagedCollection<PaymentHistory>(items.ToImmutableList(), totalCount);
        }
    }
}