using GSP.Shared.Utils.Application.UseCases.Exceptions;
using GSP.WepApi.Aggregator.DTOs.Rates;
using GSP.WepApi.Aggregator.Extensions;
using GSP.WepApi.Aggregator.Services.Api.Contracts;
using GSP.WepApi.Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Refit;
using System.Net;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services
{
    public class RateService : IRateService
    {
        private readonly IRateApiClient _rateApiClient;

        private readonly IGameApiClient _gameApiClient;

        private readonly ILogger _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RateService(
            IGameApiClient gameApiClient,
            ILogger<RateService> logger,
            IHttpContextAccessor httpContextAccessor,
            IRateApiClient rateApiClient)
        {
            _gameApiClient = gameApiClient;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _rateApiClient = rateApiClient;
        }

        public async Task<GetRateDto> CreateAsync(CreateRateDto rate)
        {
            _logger.LogInformation("Add rate for game {GameId}", rate.GameId);

            bool isExists = await IsGameExists(rate.GameId);

            if (!isExists)
            {
                throw new BusinessLogicException("GameId", "Game is not exists.");
            }

            return await _rateApiClient.CreateRateAsync(_httpContextAccessor.GetAuthorizationHeaderOrDefault(), rate);
        }

        private async ValueTask<bool> IsGameExists(long gameId)
        {
            try
            {
                await _gameApiClient.GetGameByIdAsync(gameId);
                return true;
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
        }
    }
}