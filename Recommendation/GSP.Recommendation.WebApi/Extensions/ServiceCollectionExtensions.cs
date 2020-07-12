using GSP.Recommendation.Data.Context;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string RecommendationMigrationAssemblyName = "GSP.Recommendation.Data.Migrations";

        public static IServiceCollection AddRecommendationHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<RecommendationDbContext>(configuration, RecommendationMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }
    }
}