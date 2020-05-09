using GSP.WepApi.Aggregator.DTOs.Games;
using GSP.WepApi.Aggregator.DTOs.Recommendations;
using GSP.WepApi.Aggregator.Extensions;
using GSP.WepApi.Aggregator.Services.Api.Contracts;
using GSP.WepApi.Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationApiClient _recommendationApiClient;

        private readonly IGameApiClient _gameApiClient;

        private readonly ILogger _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecommendationService(
            IRecommendationApiClient recommendationApiClient,
            IGameApiClient gameApiClient,
            ILogger<RecommendationService> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _recommendationApiClient = recommendationApiClient;
            _gameApiClient = gameApiClient;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ICollection<GetGameDto>> GetRecommendedGamesAsync(GetRecommendedGamesQueryDto query)
        {
            _logger.LogInformation("Get recommended games for {GameId}", query.GameId);

            IEnumerable<long> gameIds =
                await _recommendationApiClient.GetRecommendedGamesForGameAsync(
                    _httpContextAccessor.GetAuthorizationHeaderOrDefault(),
                    query);

            var gameIdsDto = new GetGameByIdsDto(gameIds);

            ICollection<GetGameDto> games = await _gameApiClient.GetGameByIdsAsync(gameIdsDto);

            return games;
        }
    }
}