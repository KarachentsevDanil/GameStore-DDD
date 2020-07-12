using GSP.Account.Data.Context;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Account.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string AccountMigrationAssemblyName = "GSP.Account.Data.Migrations";

        public static IServiceCollection AddAccountHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<AccountDbContext>(configuration, AccountMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }
    }
}