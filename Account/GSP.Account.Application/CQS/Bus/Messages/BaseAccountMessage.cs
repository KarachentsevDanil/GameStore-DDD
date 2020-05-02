using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Account.Application.CQS.Bus.Messages
{
    public abstract class BaseAccountMessage : IntegrationEvent
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}