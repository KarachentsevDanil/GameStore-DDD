using GSP.Shared.Utils.Common.EventBus.Base.Configurations;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.WebApi.HealthChecks.EventBus.AzureServiceBus;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Linq;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.AzureServiceBus
{
    [ResourceMap(nameof(ResourceType.EventBus), nameof(EventBusType.AzureServiceBus))]
    public class AzureServiceBusHealthCheckRegistration : IEventBusResourceHealthCheckRegistration
    {
        public IHealthChecksBuilder AddEventBusHealthCheck(IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration)
        {
            AzureServiceBusConfiguration azureServiceBusConfiguration = new AzureServiceBusConfiguration();

            configuration
                .GetSection(SettingKeyConstants.ServiceBusConfigurationKey)
                .Bind(azureServiceBusConfiguration);

            return healthChecksBuilder.Add(new HealthCheckRegistration(
                nameof(AzureServiceBusRulesHealthCheck),
                sp => new AzureServiceBusRulesHealthCheck(azureServiceBusConfiguration),
                HealthStatus.Unhealthy,
                Enumerable.Empty<string>()));
        }
    }
}