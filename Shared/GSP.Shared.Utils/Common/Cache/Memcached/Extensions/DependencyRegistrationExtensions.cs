using Enyim.Caching.Configuration;
using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.Memcached.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.Cache.Memcached.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection AddMemcachedCache(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            MemcachedConfiguration cacheConfiguration = new MemcachedConfiguration();
            configuration.Bind(nameof(MemcachedConfiguration), cacheConfiguration);
            serviceCollection.AddEnyimMemcached(c => c.Servers = new List<Server>(cacheConfiguration.Servers));
            serviceCollection.AddSingleton<ICacheManager, MemcachedCacheManager>();
            return serviceCollection;
        }
    }
}