using GSP.Order.Application.CQS.Cache.Constants;
using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Cache.Extensions
{
    public static class OrderCacheManagerExtensions
    {
        public static async Task ClearAccountOrderCacheAsync(this ICacheManager cacheManager, long accountId)
        {
            await cacheManager.RemoveAsync(string.Concat(CacheConstants.AccountGameCacheBucketKey, accountId));
            await cacheManager.RemoveAsync(string.Concat(CacheConstants.AccountCurrentOrderCacheBucketKey, accountId));
        }
    }
}