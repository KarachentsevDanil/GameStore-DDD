using GSP.Order.Domain.Entities.ValueObjects;
using GSP.Order.Domain.Enums;
using GSP.Order.Domain.Events;
using GSP.Shared.Utils.Domain.Account.Entities;
using GSP.Shared.Utils.Domain.Base;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Order.Domain.Entities
{
    public class OrderBase : BaseEntity
    {
        public OrderBase(OrderStatus status, long accountId)
        {
            OrderStatus = status;
            AccountId = accountId;
            Games = new List<OrderGame>();
        }

        private OrderBase()
        {
            Games = new List<OrderGame>();
        }

        public OrderStatus OrderStatus { get; private set; }

        public long AccountId { get; private set; }

        public ICollection<OrderGame> Games { get; private set; }

        public SharedAccount Account { get; private set; }

        public void UpdateOrderStatus(OrderStatus status)
        {
            OrderStatus = status;
        }

        public bool AddGame(long gameId)
        {
            if (Games.Any(q => q.GameId == gameId))
            {
                return false;
            }

            Games.Add(new OrderGame(gameId));
            DomainEvents.Add(new GameRemovedFromOrderEvent(Id, gameId));

            return true;
        }

        public bool RemoveGame(long gameId)
        {
            OrderGame orderGame = Games.FirstOrDefault(q => q.GameId == gameId);

            if (orderGame == null)
            {
                return false;
            }

            Games.Remove(orderGame);
            DomainEvents.Add(new GameRemovedFromOrderEvent(Id, gameId));

            return true;
        }
    }
}