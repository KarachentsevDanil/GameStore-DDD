using AutoMapper;
using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Utils.Common.EventBus.Base;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using GSP.$projectPlainName$.Application.Configurations.MapperProfiles;
using GSP.$projectPlainName$.Application.CQS.Commands.$domainName$s;
using GSP.$projectPlainName$.Application.CQS.Validations.$domainName$s;
using GSP.$projectPlainName$.Application.UseCases.Services;
using GSP.$projectPlainName$.Application.UseCases.Services.Contracts;
using $safeprojectname$.EventHandlers.Accounts;
using $safeprojectname$.Events.Accounts;
using GSP.$projectPlainName$.Data.Context;
using GSP.$projectPlainName$.Data.UnitOfWorks;
using GSP.$projectPlainName$.Domain.Entities;
using GSP.$projectPlainName$.Domain.Grids;
using GSP.$projectPlainName$.Domain.UnitOfWorks.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string $domainName$MigrationAssemblyName = "GSP.$projectPlainName$.Data.Migrations";

        public static IServiceCollection Add$domainName$HealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<$domainName$DbContext>(configuration, $domainName$MigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection Add$domainName$BackgroundWorkerLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(Add$domainName$Command));
            serviceCollection.AddScoped<IIntegrationEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountCreatedEvent, IIntegrationEventHandler<AccountCreatedEvent>>>();
            return serviceCollection;
        }
    }
}