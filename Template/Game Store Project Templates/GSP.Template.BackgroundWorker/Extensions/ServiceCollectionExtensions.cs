using AutoMapper;
using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Utils.Common.EventBus.Base;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using GSP.Template.Application.Configurations.MapperProfiles;
using GSP.Template.Application.CQS.Commands.Templates;
using GSP.Template.Application.CQS.Validations.Templates;
using GSP.Template.Application.UseCases.Services;
using GSP.Template.Application.UseCases.Services.Contracts;
using GSP.Template.BackgroundWorker.EventHandlers.Accounts;
using GSP.Template.BackgroundWorker.Events.Accounts;
using GSP.Template.Data.Context;
using GSP.Template.Data.UnitOfWorks;
using GSP.Template.Domain.Entities;
using GSP.Template.Domain.Grids;
using GSP.Template.Domain.UnitOfWorks.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Template.BackgroundWorker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string TemplateMigrationAssemblyName = "GSP.Template.Data.Migrations";

        public static IServiceCollection AddTemplateHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<TemplateDbContext>(configuration, TemplateMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection AddTemplateBackgroundWorkerLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(AddTemplateCommand));
            serviceCollection.AddScoped<IIntegrationEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountCreatedEvent, IIntegrationEventHandler<AccountCreatedEvent>>>();
            return serviceCollection;
        }
    }
}