using GSP.Payment.Domain.Events;
using GSP.Shared.Utils.Domain.Base;
using System;

namespace GSP.Payment.Domain.Entities
{
    public class PaymentHistory : BaseEntity
    {
        private PaymentHistory(long accountId, long orderId, long paymentMethodId, float amount)
        {
            AccountId = accountId;
            OrderId = orderId;
            PaymentMethodId = paymentMethodId;
            Amount = amount;
            PaidAt = DateTime.UtcNow;
        }

        private PaymentHistory()
        {
        }

        public long AccountId { get; private set; }

        public long OrderId { get; private set; }

        public long PaymentMethodId { get; private set; }

        public float Amount { get; private set; }

        public DateTime PaidAt { get; private set; }

        public static PaymentHistory Create(long accountId, long orderId, long paymentMethodId, float amount)
        {
            var paymentHistory = new PaymentHistory(accountId, orderId, paymentMethodId, amount);
            paymentHistory.DomainEvents.Add(new OrderPaidEvent(orderId, accountId));
            return paymentHistory;
        }
    }
}