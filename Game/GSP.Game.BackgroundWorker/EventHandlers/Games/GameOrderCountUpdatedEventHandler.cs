using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.BackgroundWorker.Events.Games;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Game.BackgroundWorker.EventHandlers.Games
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
            UpdateGameOrdersCountCommand command = new UpdateGameOrdersCountCommand(@event.GameId, @event.CountOfOrders);
            await _mediator.Send(command);
        }
    }
}