using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.Cache.Redis.Contracts
{
    public interface IRedisCacheDatabaseProvider : IDisposable
    {
        Task<IDatabase> GetDatabaseAsync();
    }
}