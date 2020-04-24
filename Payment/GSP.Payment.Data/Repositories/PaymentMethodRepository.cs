using GSP.Payment.Data.Context;
using GSP.Payment.Domain.Entities;
using GSP.Payment.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Data.Repositories
{
    public class PaymentMethodRepository : BaseRepository<PaymentDbContext, PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(PaymentDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<PaymentMethod>> GetListByAccountIdAsync(long accountId, CancellationToken ct)
        {
            return await DbSet.Where(q => q.AccountId == accountId).AsNoTracking().ToListAsync(ct);
        }
    }
}