using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.ServiceBus.Models
{
    public class Topic
    {
        public string Name { get; set; }

        public IEnumerable<Subscriber> Subscribers { get; set; }
    }
}