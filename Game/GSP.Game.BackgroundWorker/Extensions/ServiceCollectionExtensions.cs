using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.BackgroundWorker.EventHandlers.Games;
using GSP.Game.BackgroundWorker.Events.Games;
using GSP.Game.Data.Context;
using GSP.Shared.Utils.Common.EventBus.Base;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.BackgroundWorker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string GameMigrationAssemblyName = "GSP.Game.Data.Migrations";

        public static IServiceCollection AddGameHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<GameDbContext>(configuration, GameMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection AddGameBackgroundWorker(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(CreateGameCommand).Assembly);

            serviceCollection.AddScoped<IIntegrationEventHandler<GameOrderCountUpdatedEvent>, GameOrderCountUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameRatingUpdatedEvent>, GameRatingUpdatedEventHandler>();

            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameOrderCountUpdatedEvent, IIntegrationEventHandler<GameOrderCountUpdatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameRatingUpdatedEvent, IIntegrationEventHandler<GameRatingUpdatedEvent>>>();

            return serviceCollection;
        }
    }
}