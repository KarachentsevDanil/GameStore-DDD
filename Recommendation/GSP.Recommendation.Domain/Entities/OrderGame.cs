using GSP.Shared.Utils.Domain.Base;
using System.Collections.Generic;

namespace GSP.Recommendation.Domain.Entities
{
    public class OrderGame : ValueObject<OrderGame>
    {
        public OrderGame(long orderId, long gameId)
        {
            OrderId = orderId;
            GameId = gameId;
        }

        private OrderGame()
        {
        }

        public long Id { get; set; }

        public long OrderId { get; private set; }

        public long GameId { get; private set; }

        public override OrderGame CopyFrom(OrderGame copyFromObject)
        {
            OrderId = copyFromObject.OrderId;
            GameId = copyFromObject.GameId;

            return this;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return OrderId;
            yield return GameId;
        }
    }
}