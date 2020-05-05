using AutoMapper;
using GSP.Order.Application.CQS.Cache.Extensions;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Commands.Orders
{
    public class AddOrderToGameCommandHandler : BaseResponseHandler<AddOrderToGameCommand, GetOrderDto>
    {
        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;

        private readonly ICacheManager _cacheManager;

        public AddOrderToGameCommandHandler(
            ILogger<AddOrderToGameCommand> logger,
            IMapper mapper,
            IOrderService orderService,
            ICacheManager cacheManager)
            : base(logger)
        {
            _mapper = mapper;
            _orderService = orderService;
            _cacheManager = cacheManager;
        }

        protected override async Task<GetOrderDto> ExecuteAsync(AddOrderToGameCommand request, CancellationToken ct)
        {
            OrderGameDto orderDto = _mapper.Map<OrderGameDto>(request);
            var result = await _orderService.AddOrderGameAsync(orderDto, ct);
            await _cacheManager.ClearAccountOrderCacheAsync(request.AccountId);
            return result;
        }
    }
}