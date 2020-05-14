using System;

namespace GSP.WepApi.Aggregator.Configurations
{
    public class ApiClientConfiguration
    {
        public Uri BaseUrl { get; set; }

        public int RetryCount { get; set; }

        public int WaitDuration { get; set; }
    }
}