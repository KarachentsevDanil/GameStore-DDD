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
        private readonly List<OrderGame> _games = new List<OrderGame>();

        public OrderBase(long accountId)
        {
            AccountId = accountId;
            OrderStatus = OrderStatus.New;
        }

        private OrderBase()
        {
        }

        public OrderStatus OrderStatus { get; private set; }

        public long AccountId { get; private set; }

        public IReadOnlyCollection<OrderGame> Games => _games;

        public SharedAccount Account { get; private set; }

        public void CompleteOrder()
        {
            OrderStatus = OrderStatus.Paid;
        }

        public bool AddGame(long gameId)
        {
            if (Games.Any(q => q.GameId == gameId))
            {
                return false;
            }

            _games.Add(new OrderGame(gameId));
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

            _games.Remove(orderGame);
            DomainEvents.Add(new GameRemovedFromOrderEvent(Id, gameId));
            return true;
        }
    }
}