using MediatR;

namespace GSP.Order.Domain.Events
{
    public class GameAddedToOrderEvent : INotification
    {
        public GameAddedToOrderEvent(long orderId, long gameId)
        {
            OrderId = orderId;
            GameId = gameId;
        }

        public long OrderId { get; set; }

        public long GameId { get; set; }
    }
}