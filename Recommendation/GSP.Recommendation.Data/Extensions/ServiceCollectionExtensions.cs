using GSP.Recommendation.Data.Context;
using GSP.Recommendation.Data.UnitOfWorks;
using GSP.Recommendation.Domain.UnitOfWorks;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecommendationDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<RecommendationDbContext>(configuration);
            serviceCollection.AddScoped<IRecommendationUnitOfWork, RecommendationUnitOfWork>();
            return serviceCollection;
        }
    }
}