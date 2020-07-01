using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Context.Helpers;
using GSP.Shared.Utils.WebApi.Configurations;
using GSP.Shared.Utils.WebApi.HealthChecks.SqlServer;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;

namespace GSP.Shared.Utils.WebApi.HealthChecks.Extensions
{
    public static class HealthCheckRegistrationExtensions
    {
        public static IHealthChecksBuilder AddGspDbHealthCheck<TContext>(
            this IHealthChecksBuilder builder,
            IConfiguration configuration,
            string migrationAssemblyName)
            where TContext : GspDbContext
        {
            var entityFrameworkConfiguration = configuration
                .GetSection(nameof(EntityFrameworkConfiguration))
                .Get<EntityFrameworkConfiguration>();

            return builder.AddDbContextCheck<TContext>()
                .AddMigrationSqlServerCheck<TContext>(entityFrameworkConfiguration, migrationAssemblyName);
        }

        public static IHealthChecksBuilder AddMigrationSqlServerCheck<TContext>(
            this IHealthChecksBuilder builder,
            EntityFrameworkConfiguration dbConfiguration,
            string migrationAssembly,
            string name = default,
            HealthStatus? failureStatus = default,
            IEnumerable<string> tags = default)
        where TContext : GspDbContext
        {
            var lastMigrationName =
                DbContextHelper.GetLastDbContextMigrationName<TContext>(
                    dbConfiguration.ConnectionString,
                    migrationAssembly);

            return builder.Add(new HealthCheckRegistration(
                name ?? nameof(MigrationSqlServerHealthCheck),
                sp => new MigrationSqlServerHealthCheck(dbConfiguration.ConnectionString, lastMigrationName),
                failureStatus,
                tags));
        }

        public static IHealthChecksBuilder AddEventBusCheck(
            this IHealthChecksBuilder healthChecksBuilder,
            IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var resourceRegistryStore = serviceProvider.GetRequiredService<IResourceRegistryStore>();

                var resourceType = nameof(ResourceType.EventBus);
                var eventBusType = resourceRegistryStore.GetResourceValue(resourceType);

                var eventBusRegistrationService =
                    resourceRegistryStore.GetResource<IEventBusResourceHealthCheckRegistration>(resourceType, eventBusType);

                return eventBusRegistrationService.AddEventBusHealthCheck(healthChecksBuilder, configuration);
            }
        }
    }
}