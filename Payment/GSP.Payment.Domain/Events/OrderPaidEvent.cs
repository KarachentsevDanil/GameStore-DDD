using MediatR;

namespace GSP.Payment.Domain.Events
{
    public class OrderPaidEvent : INotification
    {
        public OrderPaidEvent(long orderId, long accountId)
        {
            OrderId = orderId;
            AccountId = accountId;
        }

        public long OrderId { get; set; }

        public long AccountId { get; set; }
    }
}