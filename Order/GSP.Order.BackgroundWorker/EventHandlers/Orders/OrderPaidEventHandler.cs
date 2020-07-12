using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.BackgroundWorker.Events.Orders;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Order.BackgroundWorker.EventHandlers.Orders
{
    public class OrderPaidEventHandler : IIntegrationEventHandler<OrderPaidEvent>
    {
        private readonly IMediator _mediator;

        public OrderPaidEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OrderPaidEvent @event)
        {
            await _mediator.Send(new CompleteOrderCommand(@event.AccountId));
        }
    }
}
