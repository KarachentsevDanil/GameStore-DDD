using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Cache.Redis.Configurations;
using GSP.Shared.Utils.Common.Cache.Redis.Contracts;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.Cache.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IRedisCacheDatabaseProvider _databaseProvider;

        private readonly RedisConfiguration _configuration;

        public RedisCacheManager(IRedisCacheDatabaseProvider databaseProvider, IOptions<RedisConfiguration> configuration)
        {
            _databaseProvider = databaseProvider;
            _configuration = configuration.Value;
        }

        public async Task AddAsync<TEntity>(TEntity entity, string key, TimeSpan? expirationTime = null)
        {
            var database = await _databaseProvider.GetDatabaseAsync();
            await database.StringSetAsync(key, JsonConvert.SerializeObject(entity), expirationTime ?? _configuration.DefaultExpirationTime);
        }

        public async Task<TEntity> GetAsync<TEntity>(string key)
        {
            var database = await _databaseProvider.GetDatabaseAsync();
            var cachedItem = await database.StringGetAsync(key);

            if (!string.IsNullOrEmpty(cachedItem))
            {
                return JsonConvert.DeserializeObject<TEntity>(cachedItem.ToString());
            }

            return default;
        }

        public async Task RemoveAsync(string key)
        {
            var database = await _databaseProvider.GetDatabaseAsync();
            await database.KeyDeleteAsync(key);
        }
    }
}