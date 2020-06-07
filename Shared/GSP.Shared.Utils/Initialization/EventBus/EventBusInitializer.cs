using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Initialization.EventBus
{
    public static class EventBusInitializer
    {
        public static async Task InitializeAsync(IConfigurationRoot configuration)
        {
            Console.WriteLine("Start Azure Service Bus initialization....");

            var registryStore = configuration.GetResourceRegistryStore();

            var resourceType = nameof(ResourceType.EventBus);
            var eventBusType = registryStore.GetResourceValue(resourceType);

            var eventBusRegistrationService =
                registryStore.GetResource<IEventBusResourceInitialization>(resourceType, eventBusType);

            await eventBusRegistrationService.InitializeEventBusAsync(configuration);

            Console.WriteLine("End Azure Service Bus initialization....");
        }
    }
}