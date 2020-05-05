using Accord.MachineLearning.Rules;
using GSP.Recommendation.Application.Configurations;
using GSP.Recommendation.Application.UseCases.DTOs.Recommendations;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.Domain.UnitOfWorks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace GSP.Recommendation.Application.UseCases.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationUnitOfWork _unitOfWork;

        private readonly ILogger _logger;

        private readonly RecommendationConfiguration _recommendationConfiguration;

        public RecommendationService(IRecommendationUnitOfWork unitOfWork, ILogger<RecommendationService> logger, IOptions<RecommendationConfiguration> recommendationConfiguration)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _recommendationConfiguration = recommendationConfiguration.Value;
        }

        public async Task<ICollection<long>> GetRecommendedGamesAsync(GetRecommendedGamesQueryDto query, CancellationToken ct = default)
        {
            _logger.LogInformation("Get recommended games for game {GameId} for account {AccountId}", query.GameId);
            var transactions = await GetGameTransactionsAsync(query, ct);
            return GetRecommendedGames(query, transactions);
        }

        private ICollection<long> GetRecommendedGames(GetRecommendedGamesQueryDto query, long[][] transactions)
        {
            var transactionalPercentage =
                transactions.Length * 100 / _recommendationConfiguration.PercentageOfTransaction;

            var apriori = new Apriori<long>(transactionalPercentage, _recommendationConfiguration.Confident);

            var classifier = apriori.Learn(transactions);

            var matches = classifier.Decide(new SortedSet<long> { query.GameId });

            return matches.SelectMany(t => t.Select(i => i)).Distinct().Take(query.Take).ToList();
        }

        private async Task<long[][]> GetGameTransactionsAsync(
            GetRecommendedGamesQueryDto query,
            CancellationToken ct)
        {
            var transactions =
                query.AccountId.HasValue ?
                await _unitOfWork.OrderRepository.GetGameTransactionsByAccountAsync(query.AccountId.Value, query.GameId, ct) :
                await _unitOfWork.OrderRepository.GetGameTransactionsByGameAsync(query.GameId, ct);

            return transactions.Select(s => s.Select(i => i.GameId).ToArray()).ToArray();
        }
    }
}