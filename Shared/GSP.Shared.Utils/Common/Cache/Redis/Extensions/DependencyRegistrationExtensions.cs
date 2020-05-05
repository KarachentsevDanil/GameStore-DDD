using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.InMemory;
using GSP.Shared.Utils.Common.Cache.InMemory.Configurations;
using GSP.Shared.Utils.Common.Cache.Redis.Configurations;
using GSP.Shared.Utils.Common.Cache.Redis.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.Common.Cache.Redis.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection AddRedisCache(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.Configure<RedisConfiguration>(nameof(RedisConfiguration), configuration);
            serviceCollection.AddSingleton<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
            serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();
            return serviceCollection;
        }
    }
}