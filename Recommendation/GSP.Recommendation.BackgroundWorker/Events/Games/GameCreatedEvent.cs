using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Recommendation.BackgroundWorker.Events.Games
{
    public class GameCreatedEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public long GenreId { get; set; }
    }
}