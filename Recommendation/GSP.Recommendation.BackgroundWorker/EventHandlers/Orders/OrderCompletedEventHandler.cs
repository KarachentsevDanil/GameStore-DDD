using GSP.Recommendation.Application.CQS.Commands.Orders;
using GSP.Recommendation.Application.UseCases.DTOs.Orders;
using GSP.Recommendation.BackgroundWorker.Events.Orders;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace GSP.Recommendation.BackgroundWorker.EventHandlers.Orders
{
    public class OrderCompletedEventHandler : IIntegrationEventHandler<OrderCompletedEvent>
    {
        private readonly IMediator _mediator;

        public OrderCompletedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OrderCompletedEvent @event)
        {
            CreateOrderCommand command =
                new CreateOrderCommand(
                    @event.OrderId,
                    @event.AccountId,
                    @event.CreationDate,
                    @event.GameIds.Select(t => new OrderGameDto(@event.OrderId, t)).ToList());

            await _mediator.Send(command);
        }
    }
}
