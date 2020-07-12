using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.BackgroundWorker.Events.Games;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Game.BackgroundWorker.EventHandlers.Games
{
    public class GameRatingUpdatedEventHandler : IIntegrationEventHandler<GameRatingUpdatedEvent>
    {
        private readonly IMediator _mediator;

        public GameRatingUpdatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(GameRatingUpdatedEvent @event)
        {
            UpdateGameRatingCommand command = new UpdateGameRatingCommand(@event.GameId, @event.CountOfReviews, @event.AverageRating);
            await _mediator.Send(command);
        }
    }
}