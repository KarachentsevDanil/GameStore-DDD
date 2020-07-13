using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace $safeprojectname$.CQS.Bus.Messages
{
    public class $domainName$UpdatedMessage : IntegrationEvent
    {
        public $domainName$UpdatedMessage(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}