using GSP.Recommendation.Application.UseCases.DTOs.Games;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.Domain.Entities;
using GSP.Recommendation.Domain.UnitOfWorks;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.UseCases.Services
{
    public class GameService : IGameService
    {
        private readonly IRecommendationUnitOfWork _unitOfWork;

        private readonly ILogger _logger;

        public GameService(IRecommendationUnitOfWork unitOfWork, ILogger<GameService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task AddAsync(AddGameDto addGame, CancellationToken ct = default)
        {
            _logger.LogInformation("Add game {@Game}", addGame);

            Game game = new Game(addGame.Id, addGame.GenreId);

            _unitOfWork.GameRepository.Create(game);

            await _unitOfWork.SaveAsync(ct);
        }

        public async Task UpdateOrderCountAsync(UpdateGameOrdersCountDto update, CancellationToken ct = default)
        {
            _logger.LogInformation("Update game order count {@Game}", update);

            Game game = await _unitOfWork.GameRepository.GetAsync(update.GameId, ct);

            game.UpdateOrderCount(update.OrdersCount);

            _unitOfWork.GameRepository.Update(game);

            await _unitOfWork.SaveAsync(ct);
        }

        public async Task UpdateRatingAsync(UpdateGameRatingDto update, CancellationToken ct = default)
        {
            _logger.LogInformation("Update game order count {@Game}", update);

            Game game = await _unitOfWork.GameRepository.GetAsync(update.GameId, ct);

            game.UpdateRating(update.ReviewsCount, update.AverageRating);

            _unitOfWork.GameRepository.Update(game);

            await _unitOfWork.SaveAsync(ct);
        }
    }
}