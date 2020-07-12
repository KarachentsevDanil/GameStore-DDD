using GSP.Rate.Data.Context;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.WebApi.Extensions
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
    }
}