using AutoMapper;
using GSP.Rate.BackgroundWorker.Configurations.MapperProfiles;
using GSP.Rate.BackgroundWorker.EventHandlers.Accounts;
using GSP.Rate.BackgroundWorker.Events.Accounts;
using GSP.Rate.Data.Context;
using GSP.Rate.Data.UnitOfWorks;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Application.Account.Configurations.MapperProfiles;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.Services;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.Base;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.BackgroundWorker.Extensions
{
    public static class DependencyRegistrationExtensions
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

        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRateUnitOfWork, RateUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(CreateAccountCommand).Assembly);

            serviceCollection.AddAutoMapper(typeof(AccountApplicationProfile), typeof(BackgroundWorkerProfile));

            serviceCollection.AddScoped<IAccountService, AccountService<IRateUnitOfWork>>();

            serviceCollection.AddScoped<IIntegrationEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<AccountUpdatedEvent>, AccountUpdatedEventHandler>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterBackgroundWorkerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountCreatedEvent, IIntegrationEventHandler<AccountCreatedEvent>>>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountUpdatedEvent, IIntegrationEventHandler<AccountUpdatedEvent>>>();

            return serviceCollection;
        }
    }
}