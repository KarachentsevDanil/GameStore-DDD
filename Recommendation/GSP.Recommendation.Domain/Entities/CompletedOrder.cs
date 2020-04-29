using GSP.Shared.Utils.Domain.Base;
using System;
using System.Collections.Generic;

namespace GSP.Recommendation.Domain.Entities
{
    public class CompletedOrder : BaseEntity
    {
        public CompletedOrder(long accountId, DateTime completedAt, ICollection<OrderGame> games)
        {
            AccountId = accountId;
            CompletedAt = completedAt;
            Games = games;
        }

        private CompletedOrder()
        {
        }

        public long AccountId { get; private set; }

        public DateTime CompletedAt { get; private set; }

        public ICollection<OrderGame> Games { get; private set; }
    }
}