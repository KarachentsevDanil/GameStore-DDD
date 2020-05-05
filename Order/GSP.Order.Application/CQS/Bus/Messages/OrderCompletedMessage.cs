using GSP.Shared.Utils.Common.ServiceBus.Base.Models;
using System.Collections.Generic;

namespace GSP.Order.Application.CQS.Bus.Messages
{
    public class OrderCompletedMessage : IntegrationEvent
    {
        public OrderCompletedMessage(long orderId, long accountId, IEnumerable<long> gameIds)
        {
            OrderId = orderId;
            AccountId = accountId;
            GameIds = gameIds;
        }

        public long OrderId { get; set; }

        public long AccountId { get; set; }

        public IEnumerable<long> GameIds { get; set; }
    }
}