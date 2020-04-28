using GSP.Payment.Application.CQS.Bus;
using GSP.Payment.Application.CQS.Bus.Messages;
using GSP.Payment.Domain.Events;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.CQS.Handlers.Notifications.PaymentHistories
{
    public class OrderPaidNotificationHandler : BaseNotificationHandler<OrderPaidEvent>
    {
        private readonly IServiceBusClient _serviceBusClient;

        public OrderPaidNotificationHandler(
            ILogger<OrderPaidEvent> logger,
            IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task ExecuteAsync(OrderPaidEvent request, CancellationToken ct)
        {
            OrderPaidMessage message = new OrderPaidMessage(request.OrderId, request.AccountId);
            await _serviceBusClient.PublishOrderPaidAsync(message);
        }
    }
}