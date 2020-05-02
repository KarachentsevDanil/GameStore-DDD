using GSP.Shared.Utils.Common.Cache.Redis.Configurations;
using GSP.Shared.Utils.Common.Cache.Redis.Contracts;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.Cache.Redis
{
    public class RedisCacheDatabaseProvider : IRedisCacheDatabaseProvider
    {
        private readonly RedisConfiguration _redisConfiguration;

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheDatabaseProvider(RedisConfiguration redisConfiguration)
        {
            _redisConfiguration = redisConfiguration;
        }

        public async Task<IDatabase> GetDatabaseAsync()
        {
            await InitializeIfNeedAsync();

            return _connectionMultiplexer.GetDatabase(_redisConfiguration.DatabaseId);
        }

        private async Task InitializeIfNeedAsync()
        {
            if (_connectionMultiplexer == null || !_connectionMultiplexer.IsConnected)
            {
                _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(_redisConfiguration.ConnectionString);
            }
        }
    }
}