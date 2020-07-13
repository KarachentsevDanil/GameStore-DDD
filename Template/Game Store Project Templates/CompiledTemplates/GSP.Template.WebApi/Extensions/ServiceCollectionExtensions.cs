using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using GSP.$projectPlainName$.Data.Context;
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
    }
}