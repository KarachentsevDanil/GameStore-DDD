using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.UseCases.Services.Contracts
{
    public interface IGameService : IBaseService<GetGameDto, AddGameDto, UpdateGameDto>
    {
        Task<PagedCollection<GetGameDto>> GetPagedListAsync(GameFilterParamsDto filterParams, CancellationToken ct = default);

        Task<GetGameDto> UpdateOrdersCountAsync(UpdateGameOrdersCountDto itemDto, CancellationToken ct = default);

        Task<GetGameDto> UpdateRatingAsync(UpdateGameRatingDto itemDto, CancellationToken ct = default);
    }
}