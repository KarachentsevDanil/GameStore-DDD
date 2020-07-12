using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Game.BackgroundWorker.Events.Games
{
    public class GameOrderCountUpdatedEvent : IntegrationEvent
    {
        public long GameId { get; set; }

        public int CountOfOrders { get; set; }
    }
}