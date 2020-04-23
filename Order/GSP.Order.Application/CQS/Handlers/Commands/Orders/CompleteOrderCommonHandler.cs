using AutoMapper;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Commands.Orders
{
    public class CompleteOrderCommonHandler : BaseResponseHandler<CompleteOrderCommand, GetOrderDto>
    {
        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;

        public CompleteOrderCommonHandler(
            ILogger<CompleteOrderCommand> logger,
            IMapper mapper,
            IOrderService orderService)
            : base(logger)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        protected override async Task<GetOrderDto> ExecuteAsync(CompleteOrderCommand request, CancellationToken ct)
        {
            CompleteOrderDto orderDto = _mapper.Map<CompleteOrderDto>(request);
            return await _orderService.CompleteAsync(orderDto, ct);
        }
    }
}