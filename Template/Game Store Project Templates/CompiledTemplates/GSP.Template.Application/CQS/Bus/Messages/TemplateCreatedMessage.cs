using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace $safeprojectname$.CQS.Bus.Messages
{
    public class $domainName$CreatedMessage : IntegrationEvent
    {
        public $domainName$CreatedMessage(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}