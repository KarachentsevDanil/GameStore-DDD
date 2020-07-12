using GSP.Shared.Utils.Common.EventBus.AzureServiceBus;
using GSP.Shared.Utils.Common.EventBus.AzureServiceBus.Configurations;
using GSP.Shared.Utils.Common.EventBus.AzureServiceBus.Contracts;
using GSP.Shared.Utils.Common.EventBus.Base.Configurations;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.AzureServiceBus
{
    [ResourceMap(nameof(ResourceType.EventBus), nameof(EventBusType.AzureServiceBus))]
    public class AzureServiceBusResourceRegistration : IEventBusResourceRegistration
    {
        public void AddEventBus(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            AzureServiceBusConfiguration azureServiceBusConfiguration = new AzureServiceBusConfiguration();

            configuration
                .GetSection(SettingKeyConstants.ServiceBusConfigurationKey)
                .Bind(azureServiceBusConfiguration);

            serviceCollection.AddSingleton<IAzureServiceBusPersistentConnection>(sp =>
                new AzureServiceBusPersistentConnection(azureServiceBusConfiguration.ConnectionString));

            serviceCollection.AddSingleton<IServiceBusClient, AzureServiceBusClient>();

            serviceCollection.Configure<AzureServiceBusSubscriptionConfiguration>(configuration.GetSection(nameof(AzureServiceBusSubscriptionConfiguration)));

            serviceCollection.AddSingleton(typeof(IServiceBusSubscriptionClient<,>), typeof(AzureServiceBusSubscriptionClient<,>));
        }
    }
}