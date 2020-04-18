using GSP.Game.Domain.Entities;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Domain.Repositories.Contracts
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<Genre> GetByNameAsync(string name, CancellationToken ct);
    }
}