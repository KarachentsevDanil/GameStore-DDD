using AutoMapper;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.BackgroundWorker.Configurations.MapperProfiles;
using GSP.Order.BackgroundWorker.EventHandlers.Accounts;
using GSP.Order.BackgroundWorker.EventHandlers.Games;
using GSP.Order.BackgroundWorker.EventHandlers.Orders;
using GSP.Order.BackgroundWorker.Events.Accounts;
using GSP.Order.BackgroundWorker.Events.Games;
using GSP.Order.BackgroundWorker.Events.Orders;
using GSP.Order.Data.Context;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Common.EventBus.Base;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Order.BackgroundWorker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string OrderMigrationAssemblyName = "GSP.Order.Data.Migrations";

        public static IServiceCollection AddOrderHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<OrderDbContext>(configuration, OrderMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection AddOrderBackgroundWorker(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(CreateAccountCommand).Assembly, typeof(CreateOrderCommand).Assembly);

            serviceCollection.AddAutoMapper(typeof(BackgroundWorkerProfile));

            serviceCollection.AddScoped<IIntegrationEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<AccountUpdatedEvent>, AccountUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameCreatedEvent>, GameCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameUpdatedEvent>, GameUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<OrderPaidEvent>, OrderPaidEventHandler>();

            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountCreatedEvent, IIntegrationEventHandler<AccountCreatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountUpdatedEvent, IIntegrationEventHandler<AccountUpdatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameCreatedEvent, IIntegrationEventHandler<GameCreatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<GameUpdatedEvent, IIntegrationEventHandler<GameUpdatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<OrderPaidEvent, IIntegrationEventHandler<OrderPaidEvent>>>();

            return serviceCollection;
        }
    }
}