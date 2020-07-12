using System.Threading.Tasks;
using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.BackgroundWorker.Events.Games;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using MediatR;

namespace GSP.Recommendation.BackgroundWorker.EventHandlers.Games
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
