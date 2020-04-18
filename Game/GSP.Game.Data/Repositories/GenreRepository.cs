using System.Linq;
using GSP.Game.Data.Context;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GSP.Game.Data.Repositories
{
    public class GenreRepository : BaseRepository<GameDbContext, Genre>, IGenreRepository
    {
        public GenreRepository(GameDbContext context)
            : base(context)
        {
        }

        public async Task<Genre> GetByNameAsync(string name, CancellationToken ct)
        {
            return await Set.FirstOrDefaultAsync(t => EF.Functions.Like(t.Name, name), ct);
        }
    }
}