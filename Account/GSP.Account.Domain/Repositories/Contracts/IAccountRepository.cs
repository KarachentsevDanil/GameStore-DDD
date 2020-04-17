using GSP.Account.Domain.Entities;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Domain.Repositories.Contracts
{
    public interface IAccountRepository : IBaseRepository<AccountBase>
    {
        Task<AccountBase> GetUserAsync(string email, CancellationToken ct);
    }
}