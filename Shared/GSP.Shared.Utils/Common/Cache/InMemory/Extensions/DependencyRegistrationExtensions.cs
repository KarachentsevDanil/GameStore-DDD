using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.InMemory.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.Common.Cache.InMemory.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection AddInMemoryCache(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            var memoryCache = new MemoryCacheConfiguration();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            configuration.Bind(nameof(MemoryCacheConfiguration), memoryCache);
            serviceCollection.AddSingleton(memoryCache);
            return serviceCollection;
        }
    }
}