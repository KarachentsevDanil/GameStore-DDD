using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Order.BackgroundWorker.Events.Orders
{
    public class OrderPaidEvent : IntegrationEvent
    {
        public long AccountId { get; set; }
    }
}