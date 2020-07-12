using GSP.Shared.Utils.Common.EventBus.Base.Models;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.EventBus.Base.Configurations
{
    public class AzureServiceBusConfiguration
    {
        public AzureServiceBusConfiguration()
        {
            Topics = new List<Topic>();
        }

        public string ConnectionString { get; set; }

        public IEnumerable<Topic> Topics { get; set; }
    }
}