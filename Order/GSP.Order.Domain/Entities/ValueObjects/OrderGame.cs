using GSP.Shared.Utils.Domain.Base;
using System.Collections.Generic;

namespace GSP.Order.Domain.Entities.ValueObjects
{
    public class OrderGame : ValueObject<OrderGame>
    {
        public OrderGame(long gameId)
        {
            GameId = gameId;
        }

        private OrderGame()
        {
        }

        public long OrderId { get; private set; }

        public long GameId { get; private set; }

        public Game Game { get; private set; }

        public override OrderGame CopyFrom(OrderGame copyFromObject)
        {
            return new OrderGame(copyFromObject.GameId)
            {
                OrderId = copyFromObject.OrderId
            };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return GameId;
            yield return OrderId;
        }
    }
}