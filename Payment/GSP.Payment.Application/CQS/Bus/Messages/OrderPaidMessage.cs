namespace GSP.Payment.Application.CQS.Bus.Messages
{
    public class OrderPaidMessage
    {
        public OrderPaidMessage(long orderId, long accountId)
        {
            OrderId = orderId;
            AccountId = accountId;
        }

        public long OrderId { get; set; }

        public long AccountId { get; set; }
    }
}