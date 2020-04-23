using GSP.Order.Application.CQS.Queries.Orders;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Queries.Orders
{
    public class GetOrdersByAccountQueryHandler : BaseResponseHandler<GetOrdersByAccountQuery, IImmutableList<GetOrderDto>>
    {
        private readonly IOrderService _orderService;

        public GetOrdersByAccountQueryHandler(
            ILogger<GetOrdersByAccountQuery> logger,
            IOrderService orderService)
            : base(logger)
        {
            _orderService = orderService;
        }

        protected override async Task<IImmutableList<GetOrderDto>> ExecuteAsync(GetOrdersByAccountQuery request, CancellationToken ct)
        {
            return await _orderService.GetListByAccountIdAsync(request.AccountId, ct);
        }
    }
}