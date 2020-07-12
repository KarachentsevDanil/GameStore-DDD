using GSP.Recommendation.Application.CQS.Commands.Orders;
using GSP.Recommendation.Application.UseCases.DTOs.Orders;
using GSP.Recommendation.BackgroundWorker.Events.Orders;
using GSP.Shared.Utils.Common.Date.Contracts;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace GSP.Recommendation.BackgroundWorker.EventHandlers.Orders
{
    public class OrderCompletedEventHandler : IIntegrationEventHandler<OrderCompletedEvent>
    {
        private readonly IMediator _mediator;

        private readonly IDateTimeService _dateTimeService;

        public OrderCompletedEventHandler(IMediator mediator, IDateTimeService dateTimeService)
        {
            _mediator = mediator;
            _dateTimeService = dateTimeService;
        }

        public async Task Handle(OrderCompletedEvent @event)
        {
            CreateOrderCommand command =
                new CreateOrderCommand(
                    @event.OrderId,
                    @event.AccountId,
                    _dateTimeService.UtcNow,
                    @event.GameIds.Select(t => new OrderGameDto(@event.OrderId, t)).ToList());

            await _mediator.Send(command);
        }
    }
}
