using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Configurations;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Constants;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
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
            string serviceBusConnection =
                configuration.GetValue<string>(ServiceBusConstants.ConnectionName);

            serviceCollection.AddSingleton<IAzureServiceBusPersistentConnection>(sp =>
                new AzureServiceBusPersistentConnection(serviceBusConnection));

            serviceCollection.AddSingleton<IServiceBusClient, AzureServiceBusClient>();

            serviceCollection.Configure<AzureServiceBusSubscriptionConfiguration>(configuration.GetSection(nameof(AzureServiceBusSubscriptionConfiguration)));

            serviceCollection.AddSingleton(typeof(IServiceBusSubscriptionClient<,>), typeof(AzureServiceBusSubscriptionClient<,>));
        }
    }
}