using GSP.Recommendation.Application.UseCases.DTOs.Recommendations;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.Domain.UnitOfWorks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.UseCases.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationUnitOfWork _unitOfWork;

        private readonly ILogger _logger;

        public RecommendationService(IRecommendationUnitOfWork unitOfWork, ILogger<RecommendationService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public Task<ICollection<long>> GetRecommendedGamesAsync(GetRecommendedGames query, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }
    }
}