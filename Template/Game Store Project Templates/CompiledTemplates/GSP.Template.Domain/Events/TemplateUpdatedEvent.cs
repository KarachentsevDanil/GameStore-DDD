using MediatR;

namespace $safeprojectname$.Events
{
    public class $domainName$UpdatedEvent : INotification
    {
        public $domainName$UpdatedEvent(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}