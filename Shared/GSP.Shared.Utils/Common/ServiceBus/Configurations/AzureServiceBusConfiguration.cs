using System.Collections.Generic;
using GSP.Shared.Utils.Common.ServiceBus.Models;

namespace GSP.Shared.Utils.Common.ServiceBus.Configurations
{
    public class AzureServiceBusConfiguration
    {
        public string ConnectionString { get; set; }

        public IEnumerable<Topic> Topics { get; set; }
    }
}