using GSP.Order.Application.CQS.Queries.Orders;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Queries.Orders
{
    public class GetCurrentOrderByAccountQueryHandler : BaseResponseHandler<GetOrderByAccountQuery, GetOrderDto>
    {
        private readonly IOrderService _orderService;

        public GetCurrentOrderByAccountQueryHandler(
            ILogger<GetOrderByAccountQuery> logger,
            IOrderService orderService)
            : base(logger)
        {
            _orderService = orderService;
        }

        protected override async Task<GetOrderDto> ExecuteAsync(GetOrderByAccountQuery request, CancellationToken ct)
        {
            return await _orderService.GetCurrentByAccountIdAsync(request.AccountId, ct);
        }
    }
}