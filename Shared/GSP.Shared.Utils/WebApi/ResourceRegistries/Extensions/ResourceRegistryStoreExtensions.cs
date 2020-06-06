using GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Extensions
{
    public static class ResourceRegistryStoreExtensions
    {
        public static IServiceCollection AddResourceRegistryStore(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var resourceRegistryStore = configuration.GetResourceRegistryStore();
            serviceCollection.AddSingleton<IResourceRegistryStore>(resourceRegistryStore);
            return serviceCollection;
        }

        public static ResourceRegistryStore GetResourceRegistryStore(this IConfiguration configuration)
        {
            var features = configuration.GetSection("Resources").GetChildren().ToDictionary(x => x.Key, x => x.Value);
            return new ResourceRegistryStore(features);
        }

        public static Type FindResourceType<TResource>(
            this Assembly executionAssembly, string resourceName, string resourceValue)
            where TResource : IResource
        {
            var resource = typeof(TResource);

            var resourceType = executionAssembly.GetTypes()
                .FirstOrDefault(t => resource.IsAssignableFrom(t) &&
                                     HasAppropriateAttribute(t, resourceName, resourceValue));

            if (resourceType == null)
            {
                throw new InvalidOperationException($"Implementation {resourceValue} for resource {resourceName} not found.");
            }

            return resourceType;
        }

        private static bool HasAppropriateAttribute(
            Type typeInfo, string resourceName, string resourceValue)
        {
            var resourceRegistryMapAttribute = typeInfo.GetCustomAttribute<ResourceMapAttribute>();

            return resourceRegistryMapAttribute?.ResourceName == resourceName &&
                   resourceRegistryMapAttribute?.ResourceValue == resourceValue;
        }
    }
}