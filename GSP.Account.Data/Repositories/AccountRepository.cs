using GSP.Account.Data.Context;
using GSP.Account.Domain.Entities;
using GSP.Account.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Data.Repositories
{
    public class AccountRepository : BaseRepository<AccountDbContext, AccountBase>, IAccountRepository
    {
        private readonly DbSet<AccountBase> _accounts;

        public AccountRepository(AccountDbContext context)
            : base(context)
        {
            _accounts = context.Set<AccountBase>();
        }

        public async Task<AccountBase> GetUserAsync(string email, CancellationToken ct)
        {
            return await _accounts.FirstOrDefaultAsync(t => t.Email == email, ct);
        }
    }
}