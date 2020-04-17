using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.ServiceBus.Models
{
    public class Subscriber
    {
        public string Name { get; set; }

        public IEnumerable<string> Labels { get; set; }
    }
}