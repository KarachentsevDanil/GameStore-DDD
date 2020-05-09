using GSP.WepApi.Aggregator.Constants;
using GSP.WepApi.Aggregator.DTOs.Recommendations;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Api.Contracts
{
    public interface IRecommendationApiClient
    {
        [Get("/api/recommendation")]
        Task<IEnumerable<long>> GetRecommendedGamesForGameAsync(
            [Header(HeaderConstants.Authorization)] string authHeader,
            [Query]GetRecommendedGamesQueryDto query);
    }
}