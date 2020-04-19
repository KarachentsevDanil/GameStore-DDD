using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.UseCases.Services.Contracts
{
    public interface IGenreService : IBaseService<GetGenreDto, AddGenreDto, UpdateGenreDto>
    {
        Task<GetGenreDto> GetByNameAsync(string name, CancellationToken ct = default);
    }
}