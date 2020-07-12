using AutoMapper;
using GSP.Recommendation.Application.Configurations;
using GSP.Recommendation.Application.Configurations.MapperProfiles;
using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.Application.UseCases.Services;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Recommendation.BackgroundWorker.EventHandlers.Games;
using GSP.Recommendation.BackgroundWorker.Events.Games;
using GSP.Recommendation.BackgroundWorker.Events.Orders;
using GSP.Recommendation.Data.Context;
using GSP.Recommendation.Data.UnitOfWorks;
using GSP.Recommendation.Domain.UnitOfWorks;
using GSP.Shared.Utils.Common.EventBus.Base;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Recommendation.BackgroundWorker.Extensions
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

        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRecommendationUnitOfWork, RecommendationUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMediatR(typeof(CreateGameCommand).Assembly);

            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));

            serviceCollection.Configure<RecommendationConfiguration>(nameof(RecommendationConfiguration), configuration);

            serviceCollection.AddScoped<IRecommendationService, RecommendationService>();
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();

            serviceCollection.AddScoped<IIntegrationEventHandler<GameCreatedEvent>, GameCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameOrderCountUpdatedEvent>, GameOrderCountUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameRatingUpdatedEvent>, GameRatingUpdatedEventHandler>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterBackgroundWorkerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameOrderCountUpdatedEvent, IIntegrationEventHandler<GameOrderCountUpdatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameRatingUpdatedEvent, IIntegrationEventHandler<GameRatingUpdatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameCreatedEvent, IIntegrationEventHandler<GameCreatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<OrderCompletedEvent, IIntegrationEventHandler<OrderCompletedEvent>>>();

            return serviceCollection;
        }
    }
}