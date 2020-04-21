using MediatR;

namespace GSP.Order.Domain.Events
{
    public class GameRemovedFromOrderEvent : INotification
    {
        public GameRemovedFromOrderEvent(long orderId, long gameId)
        {
            OrderId = orderId;
            GameId = gameId;
        }

        public long OrderId { get; set; }

        public long GameId { get; set; }
    }
}