using StackExchange.Redis;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.Cache.Redis.Contracts
{
    public interface IRedisCacheDatabaseProvider
    {
        Task<IDatabase> GetDatabaseAsync();
    }
}