using Enyim.Caching;
using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.Memcached.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.Cache.Memcached
{
    public class MemcachedCacheManager : ICacheManager
    {
        private readonly IMemcachedClient _memoryCache;

        private readonly MemcachedConfiguration _configuration;

        public MemcachedCacheManager(IMemcachedClient memoryCache, IOptions<MemcachedConfiguration> configuration)
        {
            _memoryCache = memoryCache;
            _configuration = configuration.Value;
        }

        public async Task AddAsync<TEntity>(TEntity entity, string key, TimeSpan? expirationTime = null)
        {
            var expirationTimeInSecond = expirationTime?.Seconds ?? _configuration.DefaultExpirationTimeInSecond;

            await _memoryCache.SetAsync(key, entity, expirationTimeInSecond);
        }

        public async Task<TEntity> GetAsync<TEntity>(string key)
        {
            var value = await _memoryCache.GetValueAsync<TEntity>(key);

            return value;
        }

        public async Task RemoveAsync(string key)
        {
            await _memoryCache.RemoveAsync(key);
        }
    }
}