using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.InMemory.Configurations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.Cache.InMemory
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        private readonly MemoryCacheConfiguration _configuration;

        public MemoryCacheManager(IMemoryCache memoryCache, IOptions<MemoryCacheConfiguration> configuration)
        {
            _memoryCache = memoryCache;
            _configuration = configuration.Value;
        }

        public Task AddAsync<TEntity>(TEntity entity, string key, TimeSpan? expirationTime = null)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(expirationTime ?? _configuration.DefaultExpirationTime);

            _memoryCache.Set(key, entity, cacheOptions);

            return Task.CompletedTask;
        }

        public Task<TEntity> GetAsync<TEntity>(string key)
        {
            bool isExists = _memoryCache.TryGetValue(key, out TEntity value);

            if (isExists)
            {
                return Task.FromResult(value);
            }

            return Task.FromResult(default(TEntity));
        }

        public Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }
    }
}