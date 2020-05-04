using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.BackgroundWorker.Events.Games;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Recommendation.BackgroundWorker.EventHandlers.Games
{
    public class GameCreatedEventHandler : IIntegrationEventHandler<GameCreatedEvent>
    {
        private readonly IMediator _mediator;

        public GameCreatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(GameCreatedEvent @event)
        {
            CreateGameCommand command = new CreateGameCommand(@event.Id, @event.GenreId);
            await _mediator.Send(command);
        }
    }
}
