using AutoMapper;
using GSP.Recommendation.Application.Configurations.MapperProfiles;
using GSP.Recommendation.Application.CQS.Handlers.Commands.Games;
using GSP.Recommendation.Application.UseCases.Services;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.Data.UnitOfWorks;
using GSP.Recommendation.Domain.UnitOfWorks;
using GSP.Recommendation.Worker.Configurations.MapperProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.Worker.Extensions
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
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile), typeof(WorkerProfile));
            serviceCollection.AddScoped<IRecommendationService, RecommendationService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<IGameService, GameService>();

            serviceCollection.AddMediatR(typeof(UpdateGameRatingCommandHandler).Assembly);

            return serviceCollection;
        }
    }
}