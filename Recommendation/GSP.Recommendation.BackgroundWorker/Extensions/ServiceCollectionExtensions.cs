using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.BackgroundWorker.EventHandlers.Games;
using GSP.Recommendation.BackgroundWorker.Events.Games;
using GSP.Recommendation.BackgroundWorker.Events.Orders;
using GSP.Recommendation.Data.Context;
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

        public static IServiceCollection AddRecommendationBackgroundWorker(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(CreateGameCommand).Assembly);

            serviceCollection.AddScoped<IIntegrationEventHandler<GameCreatedEvent>, GameCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameOrderCountUpdatedEvent>, GameOrderCountUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameRatingUpdatedEvent>, GameRatingUpdatedEventHandler>();

            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameOrderCountUpdatedEvent, IIntegrationEventHandler<GameOrderCountUpdatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameRatingUpdatedEvent, IIntegrationEventHandler<GameRatingUpdatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameCreatedEvent, IIntegrationEventHandler<GameCreatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<OrderCompletedEvent, IIntegrationEventHandler<OrderCompletedEvent>>>();

            return serviceCollection;
        }
    }
}