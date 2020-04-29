using GSP.Recommendation.Application.UseCases.DTOs.Games;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.UseCases.Services.Contracts
{
    public interface IGameService
    {
        Task AddAsync(AddGameDto addGame, CancellationToken ct = default);

        Task UpdateOrderCountAsync(UpdateGameOrdersCountDto update, CancellationToken ct = default);

        Task UpdateRatingAsync(UpdateGameRatingDto update, CancellationToken ct = default);
    }
}