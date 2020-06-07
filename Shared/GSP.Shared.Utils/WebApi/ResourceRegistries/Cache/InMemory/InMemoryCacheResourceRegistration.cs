using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.InMemory;
using GSP.Shared.Utils.Common.Cache.InMemory.Configurations;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.InMemory
{
    [ResourceMap(nameof(ResourceType.Cache), nameof(CacheType.InMemory))]
    public class InMemoryCacheResourceRegistration : ICacheResourceRegistration
    {
        public void AddCache(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var memoryCache = new MemoryCacheConfiguration();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            configuration.Bind(nameof(MemoryCacheConfiguration), memoryCache);
            serviceCollection.AddSingleton(memoryCache);
        }
    }
}