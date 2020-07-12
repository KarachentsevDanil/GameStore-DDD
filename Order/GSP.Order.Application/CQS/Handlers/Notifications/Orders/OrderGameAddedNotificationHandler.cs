using GSP.Order.Application.CQS.Bus;
using GSP.Order.Application.CQS.Bus.Messages;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Order.Domain.Events;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Notifications.Orders
{
    public class OrderGameAddedNotificationHandler : BaseNotificationHandler<GameAddedToOrderEvent>
    {
        private readonly IOrderService _orderService;

        private readonly IServiceBusClient _serviceBusClient;

        public OrderGameAddedNotificationHandler(
            ILogger<GameAddedToOrderEvent> logger,
            IOrderService orderService,
            IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _orderService = orderService;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task ExecuteAsync(GameAddedToOrderEvent request, CancellationToken ct)
        {
            var countOfOrder = await _orderService.GetOrderCountByGameIdAsync(request.GameId, ct);
            var busEvent = new GameOrderCountUpdatedMessage(request.GameId, countOfOrder);
            await _serviceBusClient.PublishGameOrderCountUpdatedAsync(busEvent);
        }
    }
}