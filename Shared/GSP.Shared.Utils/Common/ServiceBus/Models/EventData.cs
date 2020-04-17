namespace GSP.Shared.Utils.Common.ServiceBus.Models
{
    public class EventData
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string EventType { get; set; }

        public string Body { get; set; }
    }
}