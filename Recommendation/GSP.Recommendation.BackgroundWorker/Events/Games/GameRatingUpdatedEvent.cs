using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Recommendation.BackgroundWorker.Events.Games
{
    public class GameRatingUpdatedEvent : IntegrationEvent
    {
        public long GameId { get; set; }

        public int CountOfReviews { get; set; }

        public float AverageRating { get; set; }
    }
}