using AutoMapper;
using GSP.Rate.BackgroundWorker.Configurations.MapperProfiles;
using GSP.Rate.BackgroundWorker.EventHandlers.Accounts;
using GSP.Rate.BackgroundWorker.Events.Accounts;
using GSP.Rate.Data.Context;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Common.EventBus.Base;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.BackgroundWorker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string RateMigrationAssemblyName = "GSP.Rate.Data.Migrations";

        public static IServiceCollection AddRateHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<RateDbContext>(configuration, RateMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection AddRateBackgroundWorker(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(CreateAccountCommand).Assembly);
            serviceCollection.AddAutoMapper(typeof(BackgroundWorkerProfile));

            serviceCollection.AddScoped<IIntegrationEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<AccountUpdatedEvent>, AccountUpdatedEventHandler>();

            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountCreatedEvent, IIntegrationEventHandler<AccountCreatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountUpdatedEvent, IIntegrationEventHandler<AccountUpdatedEvent>>>();

            return serviceCollection;
        }
    }
}