using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Rate.BackgroundWorker.Events.Accounts
{
    public class AccountUpdatedEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}