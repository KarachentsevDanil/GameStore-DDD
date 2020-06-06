using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection AddEventBus(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var resourceRegistryStore = serviceProvider.GetRequiredService<IResourceRegistryStore>();

                var resourceType = nameof(ResourceType.EventBus);
                var eventBusType = resourceRegistryStore.GetResourceValue(resourceType);

                var eventBusRegistrationService =
                    resourceRegistryStore.GetResource<IEventBusResourceRegistration>(resourceType, eventBusType);

                eventBusRegistrationService.AddEventBus(serviceCollection, configuration);
            }

            return serviceCollection;
        }
    }
}