using MediatR;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Domain.Base
{
    public abstract class BaseEntity
    {
        public long Id { get; protected set; }

        public bool IsDeleted { get; private set; }

        public ICollection<INotification> DomainEvents { get; } = new List<INotification>();

        public virtual void Delete()
        {
            IsDeleted = true;
        }

        public virtual void Restore()
        {
            IsDeleted = false;
        }
    }
}