using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Order.BackgroundWorker.Events.Orders
{
    public class OrderPaidEvent : IntegrationEvent
    {
        public long AccountId { get; set; }
    }
}