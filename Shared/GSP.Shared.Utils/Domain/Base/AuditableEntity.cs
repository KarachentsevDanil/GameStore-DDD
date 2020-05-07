using System;

namespace GSP.Shared.Utils.Domain.Base
{
    public abstract class AuditableEntity : BaseEntity
    {
        public long CreatedByAccountId { get; set; }

        public DateTime CreatedAt { get; private set; }

        public long UpdatedByAccountId { get; set; }

        public DateTime UpdatedAt { get; private set; }

        public void SetCreatedInfo(long accountId, DateTime date)
        {
            CreatedByAccountId = UpdatedByAccountId = accountId;
            CreatedAt = UpdatedAt = date;
        }

        public void SetUpdatedInfo(long accountId, DateTime date)
        {
            UpdatedByAccountId = accountId;
            UpdatedAt = date;
        }
    }
}