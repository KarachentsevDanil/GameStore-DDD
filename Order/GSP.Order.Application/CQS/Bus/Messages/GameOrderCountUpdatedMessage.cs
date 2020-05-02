using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Order.Application.CQS.Bus.Messages
{
    public class GameOrderCountUpdatedMessage : IntegrationEvent
    {
        public GameOrderCountUpdatedMessage(long gameId, int countOfOrders)
        {
            GameId = gameId;
            CountOfOrders = countOfOrders;
        }

        public long GameId { get; set; }

        public int CountOfOrders { get; set; }
    }
}