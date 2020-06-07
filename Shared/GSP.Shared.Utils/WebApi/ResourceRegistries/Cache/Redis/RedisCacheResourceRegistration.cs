using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.Redis;
using GSP.Shared.Utils.Common.Cache.Redis.Configurations;
using GSP.Shared.Utils.Common.Cache.Redis.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Redis
{
    [ResourceMap(nameof(ResourceType.Cache), nameof(CacheType.Redis))]
    public class RedisCacheResourceRegistration : ICacheResourceRegistration
    {
        public void AddCache(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<RedisConfiguration>(nameof(RedisConfiguration), configuration);
            serviceCollection.AddSingleton<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
            serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();
        }
    }
}