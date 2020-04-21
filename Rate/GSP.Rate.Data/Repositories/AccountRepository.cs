using GSP.Rate.Data.Context;
using GSP.Rate.Domain.Entities;
using GSP.Rate.Domain.Repositories;
using GSP.Shared.Utils.Data.Repositories;

namespace GSP.Rate.Data.Repositories
{
    public class AccountRepository : BaseRepository<RateDbContext, Account>, IAccountRepository
    {
        public AccountRepository(RateDbContext context)
            : base(context)
        {
        }
    }
}