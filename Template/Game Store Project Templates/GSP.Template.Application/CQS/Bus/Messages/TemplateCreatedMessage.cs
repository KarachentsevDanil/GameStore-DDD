using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Template.Application.CQS.Bus.Messages
{
    public class TemplateCreatedMessage : IntegrationEvent
    {
        public TemplateCreatedMessage(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}