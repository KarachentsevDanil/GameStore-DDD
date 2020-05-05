using AutoMapper;
using GSP.Order.Application.CQS.Bus;
using GSP.Order.Application.CQS.Bus.Messages;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Commands.Orders
{
    public class CompleteOrderCommonHandler : BaseResponseHandler<CompleteOrderCommand, GetOrderDto>
    {
        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;

        private readonly IServiceBusClient _serviceBusClient;

        public CompleteOrderCommonHandler(
            ILogger<CompleteOrderCommand> logger,
            IMapper mapper,
            IOrderService orderService,
            IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _mapper = mapper;
            _orderService = orderService;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task<GetOrderDto> ExecuteAsync(CompleteOrderCommand request, CancellationToken ct)
        {
            CompleteOrderDto orderDto = _mapper.Map<CompleteOrderDto>(request);
            var result = await _orderService.CompleteAsync(orderDto, ct);

            var orderCompletedMessage =
                new OrderCompletedMessage(result.Id, request.AccountId, result.Games.Select(t => t.Id).ToList());
            await _serviceBusClient.PublishOrderCompletedAsync(orderCompletedMessage);

            return result;
        }
    }
}