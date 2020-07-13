using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Template.BackgroundWorker.Events.Accounts
{
    public class AccountCreatedEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public string Email { get; set; }
    }
}