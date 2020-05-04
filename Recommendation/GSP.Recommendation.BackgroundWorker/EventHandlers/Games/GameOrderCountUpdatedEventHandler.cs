using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.BackgroundWorker.Events.Games;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Recommendation.BackgroundWorker.EventHandlers.Games
{
    public class GameOrderCountUpdatedEventHandler : IIntegrationEventHandler<GameOrderCountUpdatedEvent>
    {
        private readonly IMediator _mediator;

        public GameOrderCountUpdatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(GameOrderCountUpdatedEvent @event)
        {
            UpdateGameOrderCountCommand command = new UpdateGameOrderCountCommand(@event.GameId, @event.CountOfOrders);
            await _mediator.Send(command);
        }
    }
}
