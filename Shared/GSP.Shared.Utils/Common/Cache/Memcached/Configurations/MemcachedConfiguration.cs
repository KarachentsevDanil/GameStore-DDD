using Enyim.Caching.Configuration;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.Cache.Memcached.Configurations
{
    public class MemcachedConfiguration
    {
        public ICollection<Server> Servers { get; set; }

        public int DefaultExpirationTimeInSecond { get; set; }
    }
}