using MediatR;

namespace GSP.Template.Domain.Events
{
    public class TemplateUpdatedEvent : INotification
    {
        public TemplateUpdatedEvent(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}