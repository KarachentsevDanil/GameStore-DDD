using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.EventBus.Base.Models
{
    public class Topic
    {
        public Topic()
        {
            Subscribers = new List<Subscriber>();
        }

        public string Name { get; set; }

        public IEnumerable<Subscriber> Subscribers { get; set; }
    }
}