using Newtonsoft.Json;
using System;

namespace GSP.Shared.Utils.Common.ServiceBus.Base.Models
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            EventId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid eventId, DateTime createDate)
        {
            EventId = eventId;
            CreationDate = createDate;
        }

        [JsonProperty]
        public Guid EventId { get; private set; }

        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}