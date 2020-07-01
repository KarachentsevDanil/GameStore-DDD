using AutoMapper;
using GSP.Recommendation.Application.Configurations;
using GSP.Recommendation.Application.Configurations.MapperProfiles;
using GSP.Recommendation.Application.UseCases.Services;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.Data.Context;
using GSP.Recommendation.Data.UnitOfWorks;
using GSP.Recommendation.Domain.UnitOfWorks;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.WebApi.Extensions
{
    public static class DependencyRegistrationExtensions
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

        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRecommendationUnitOfWork, RecommendationUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
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