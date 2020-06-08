using System.Collections.Generic;
using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Shared.Utils.Common.ServiceBus.Base.Configurations
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