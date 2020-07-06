using AutoMapper;
using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.Base;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using GSP.Template.Application.Configurations.MapperProfiles;
using GSP.Template.Application.CQS.Commands.Templates;
using GSP.Template.Application.CQS.Validations.Templates;
using GSP.Template.Application.UseCases.Services;
using GSP.Template.Application.UseCases.Services.Contracts;
using GSP.Template.BackgroundWorker.Events.Accounts;
using GSP.Template.Data.Context;
using GSP.Template.Data.UnitOfWorks;
using GSP.Template.Domain.Entities;
using GSP.Template.Domain.Grids;
using GSP.Template.Domain.UnitOfWorks.Contracts;
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

        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITemplateUnitOfWork, TemplateUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));
            serviceCollection.AddScoped<ITemplateService, TemplateService>();
            serviceCollection.AddGridTypeStore();
            serviceCollection.AddGrid<TemplateBase, TemplateGrid>();
            serviceCollection.AddSingleton<IValidator<AddTemplateCommand>, AddTemplateValidator>();
            serviceCollection.AddSingleton<IValidator<UpdateTemplateCommand>, UpdateTemplateValidator>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterBackgroundWorkerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<EventBusSubscriptionClient<AccountCreatedEvent, IIntegrationEventHandler<AccountCreatedEvent>>>();

            return serviceCollection;
        }
    }
}