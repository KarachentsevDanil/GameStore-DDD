using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Order.BackgroundWorker.Events.Accounts
{
    public class AccountUpdatedEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}