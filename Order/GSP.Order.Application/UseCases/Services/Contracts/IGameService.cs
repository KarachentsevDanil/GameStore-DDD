using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.UseCases.Services.Contracts
{
    public interface IGameService : IBaseService<GetGameDto, AddGameDto, UpdateGameDto>
    {
        Task<IImmutableList<GetGameDto>> GetGameByAccountIdAsync(long accountId, CancellationToken ct = default);
    }
}