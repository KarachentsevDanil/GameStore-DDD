using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using GSP.Template.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Template.WebApi.Extensions
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
    }
}