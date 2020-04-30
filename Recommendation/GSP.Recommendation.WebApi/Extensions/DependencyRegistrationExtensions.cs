using AutoMapper;
using GSP.Recommendation.Application.Configurations.MapperProfiles;
using GSP.Recommendation.Application.UseCases.Services;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.Data.UnitOfWorks;
using GSP.Recommendation.Domain.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.WebApi.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRecommendationUnitOfWork, RecommendationUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<IRecommendationService, RecommendationService>();
            return serviceCollection;
        }
    }
}