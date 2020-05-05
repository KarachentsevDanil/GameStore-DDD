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
            serviceCollection.AddMemoryCache();
            serviceCollection.Configure<MemoryCacheConfiguration>(nameof(MemoryCacheConfiguration), configuration);
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            return serviceCollection;
        }
    }
}