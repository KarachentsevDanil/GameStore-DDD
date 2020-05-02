using System;

namespace GSP.Shared.Utils.Common.Cache.Redis.Configurations
{
    public class RedisConfiguration
    {
        public string ConnectionString { get; set; }

        public int DatabaseId { get; set; }

        public TimeSpan DefaultExpirationTime { get; set; }
    }
}