using GSP.Shared.Utils.Common.EventBus.Base.Models;
using System.Collections.Generic;

namespace GSP.Recommendation.BackgroundWorker.Events.Orders
{
    public class OrderCompletedEvent : IntegrationEvent
    {
        public long OrderId { get; set; }

        public long AccountId { get; set; }

        public IEnumerable<long> GameIds { get; set; }
    }
}
