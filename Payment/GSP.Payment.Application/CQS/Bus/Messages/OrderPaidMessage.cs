﻿using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Payment.Application.CQS.Bus.Messages
{
    public class OrderPaidMessage : IntegrationEvent
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