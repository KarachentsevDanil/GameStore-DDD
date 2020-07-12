using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.EventBus.Base.Models
{
    public class Subscriber
    {
        public string Name { get; set; }

        public IEnumerable<string> Labels { get; set; }
    }
}