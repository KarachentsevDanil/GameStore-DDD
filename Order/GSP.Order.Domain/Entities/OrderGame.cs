using GSP.Shared.Utils.Domain.Base;
using System;

namespace GSP.Order.Domain.Entities
{
    public class OrderGame : BaseEntity
    {
        public OrderGame(long gameId)
        {
            GameId = gameId;
            CreatedAt = DateTime.UtcNow;
        }

        private OrderGame()
        {
        }

        public long OrderId { get; private set; }

        public long GameId { get; private set; }

        public OrderBase Order { get; private set; }

        public Game Game { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}