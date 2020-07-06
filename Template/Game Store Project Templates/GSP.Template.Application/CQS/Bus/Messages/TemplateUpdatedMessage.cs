using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Template.Application.CQS.Bus.Messages
{
    public class TemplateUpdatedMessage : IntegrationEvent
    {
        public TemplateUpdatedMessage(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}