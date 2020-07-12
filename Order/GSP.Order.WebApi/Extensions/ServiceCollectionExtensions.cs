using GSP.Order.Data.Context;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Order.WebApi.Extensions
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
    }
}