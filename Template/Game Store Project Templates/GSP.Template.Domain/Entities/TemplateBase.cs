using GSP.Shared.Utils.Domain.Base;
using GSP.Template.Domain.Events;

namespace GSP.Template.Domain.Entities
{
    public class TemplateBase : AuditableEntity
    {
        public TemplateBase(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void Update(string name)
        {
            Name = name;

            var updateEvent = new TemplateUpdatedEvent(Id, Name);
            DomainEvents.Add(updateEvent);
        }
    }
}