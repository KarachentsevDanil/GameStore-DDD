using AutoMapper;
using GSP.Recommendation.Application.Configurations;
using GSP.Recommendation.Application.Configurations.MapperProfiles;
using GSP.Recommendation.Application.UseCases.Services;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecommendationApplicationLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));
            serviceCollection.Configure<RecommendationConfiguration>(nameof(RecommendationConfiguration), configuration);
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<IRecommendationService, RecommendationService>();
            return serviceCollection;
        }
    }
}