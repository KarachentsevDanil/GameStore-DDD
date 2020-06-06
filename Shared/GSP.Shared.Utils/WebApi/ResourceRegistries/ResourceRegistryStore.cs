using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries
{
    public class ResourceRegistryStore : IResourceRegistryStore
    {
        private readonly IDictionary<string, string> _registryStore;

        public ResourceRegistryStore(IDictionary<string, string> registryStore)
        {
            _registryStore = registryStore;
        }

        public string GetResourceValue(string resourceType)
        {
            return _registryStore.TryGetValue(resourceType, out string resourceValue) ? resourceValue : default;
        }

        public TResource GetResource<TResource>(string resourceType, string resourceValue)
            where TResource : class, IResource
        {
            var featureImplementationType = Assembly.GetExecutingAssembly()
                .FindResourceType<TResource>(resourceType, resourceValue);

            return Activator.CreateInstance(featureImplementationType) as TResource;
        }
    }
}