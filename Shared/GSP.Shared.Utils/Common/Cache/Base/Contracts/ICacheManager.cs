using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.Cache.Base.Contracts
{
    public interface ICacheManager
    {
        Task AddAsync<TEntity>(TEntity entity, string key, TimeSpan? expirationTime = null);

        Task<TEntity> GetAsync<TEntity>(string key);

        Task RemoveAsync(string key);
    }
}