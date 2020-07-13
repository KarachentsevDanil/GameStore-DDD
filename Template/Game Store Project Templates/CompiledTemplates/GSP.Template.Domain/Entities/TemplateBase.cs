using GSP.Shared.Utils.Domain.Base;
using $safeprojectname$.Events;

namespace $safeprojectname$.Entities
{
    public class $domainName$Base : AuditableEntity
    {
        public $domainName$Base(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void Update(string name)
        {
            Name = name;

            var updateEvent = new $domainName$UpdatedEvent(Id, Name);
            DomainEvents.Add(updateEvent);
        }
    }
}