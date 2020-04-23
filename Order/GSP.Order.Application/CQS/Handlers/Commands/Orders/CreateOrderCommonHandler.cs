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
    public class CreateOrderCommonHandler : BaseResponseHandler<CreateOrderCommand, GetOrderDto>
    {
        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;

        public CreateOrderCommonHandler(
            ILogger<CreateOrderCommand> logger,
            IMapper mapper,
            IOrderService orderService)
            : base(logger)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        protected override async Task<GetOrderDto> ExecuteAsync(CreateOrderCommand request, CancellationToken ct)
        {
            AddOrderDto orderDto = _mapper.Map<AddOrderDto>(request);
            return await _orderService.AddAsync(orderDto, ct);
        }
    }
}