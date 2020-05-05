using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Repositories;
using GSP.Shared.Utils.Domain.Account.Entities;
using GSP.Shared.Utils.Domain.Account.Repositories.Contracts;

namespace GSP.Shared.Utils.Data.Account.Repositories
{
    public class AccountRepository<TContext> : BaseRepository<TContext, SharedAccount>, IAccountRepository
        where TContext : GspDbContext
    {
        public AccountRepository(TContext context)
            : base(context)
        {
        }
    }
}