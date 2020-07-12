using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCache(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var resourceRegistryStore = serviceProvider.GetRequiredService<IResourceRegistryStore>();

                var resourceType = nameof(ResourceType.Cache);
                var cacheType = resourceRegistryStore.GetResourceValue(resourceType);

                var cacheRegistrationService =
                    resourceRegistryStore.GetResource<ICacheResourceRegistration>(resourceType, cacheType);

                cacheRegistrationService.AddCache(serviceCollection, configuration);
            }

            return serviceCollection;
        }
    }
}