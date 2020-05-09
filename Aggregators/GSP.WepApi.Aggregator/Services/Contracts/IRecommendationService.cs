using GSP.WepApi.Aggregator.DTOs.Games;
using GSP.WepApi.Aggregator.DTOs.Recommendations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Contracts
{
    public interface IRecommendationService
    {
        Task<ICollection<GetGameDto>> GetRecommendedGamesAsync(GetRecommendedGamesQueryDto query);
    }
}