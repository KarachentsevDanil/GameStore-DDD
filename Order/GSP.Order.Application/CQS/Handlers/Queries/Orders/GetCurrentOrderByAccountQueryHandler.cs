using GSP.Order.Application.CQS.Cache.Constants;
using GSP.Order.Application.CQS.Queries.Orders;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Queries.Orders
{
    public class GetCurrentOrderByAccountQueryHandler : BaseCachedResponseHandler<GetOrderByAccountQuery, GetOrderDto>
    {
        private readonly IOrderService _orderService;

        public GetCurrentOrderByAccountQueryHandler(
            ILogger<GetOrderByAccountQuery> logger,
            ICacheManager cacheManager,
            IOrderService orderService)
            : base(logger, cacheManager)
        {
            _orderService = orderService;
        }

        protected override async Task<GetOrderDto> ExecuteAsync(GetOrderByAccountQuery request, CancellationToken ct)
        {
            return await _orderService.GetCurrentByAccountIdAsync(request.AccountId, ct);
        }

        protected override string GetCacheKey(GetOrderByAccountQuery request)
        {
            return string.Concat(CacheConstants.AccountCurrentOrderCacheBucketKey, request.AccountId);
        }
    }
}