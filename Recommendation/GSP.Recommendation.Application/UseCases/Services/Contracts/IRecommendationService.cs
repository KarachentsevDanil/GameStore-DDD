using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GSP.Recommendation.Application.UseCases.DTOs.Recommendations;

namespace GSP.Recommendation.Application.UseCases.Services.Contracts
{
    public interface IRecommendationService
    {
        Task<ICollection<long>> GetRecommendedGamesAsync(GetRecommendedGames query, CancellationToken ct = default);
    }
}