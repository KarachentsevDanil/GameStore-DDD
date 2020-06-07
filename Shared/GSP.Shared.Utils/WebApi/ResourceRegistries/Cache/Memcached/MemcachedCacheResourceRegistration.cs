using Enyim.Caching.Configuration;
using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.Memcached;
using GSP.Shared.Utils.Common.Cache.Memcached.Configurations;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Memcached
{
    [ResourceMap(nameof(ResourceType.Cache), nameof(CacheType.Memcached))]
    public class MemcachedCacheResourceRegistration : ICacheResourceRegistration
    {
        public void AddCache(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            MemcachedConfiguration cacheConfiguration = new MemcachedConfiguration();
            configuration.Bind(nameof(MemcachedConfiguration), cacheConfiguration);
            serviceCollection.AddEnyimMemcached(c => c.Servers = new List<Server>(cacheConfiguration.Servers));
            serviceCollection.AddSingleton<ICacheManager, MemcachedCacheManager>();
        }
    }
}