using GSP.Shared.Utils.Data.Repositories;
using GSP.Shared.Utils.Domain.Account.Entities;
using GSP.Shared.Utils.Domain.Account.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GSP.Shared.Utils.Data.Account.Repositories
{
    public class AccountRepository<TContext> : BaseRepository<TContext, SharedAccount>, IAccountRepository
        where TContext : DbContext
    {
        public AccountRepository(TContext context)
            : base(context)
        {
        }
    }
}