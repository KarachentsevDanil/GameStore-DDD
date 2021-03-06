﻿namespace GSP.Shared.Utils.Common.EventBus.AzureServiceBus.Configurations
{
    public class AzureServiceBusSubscriptionConfiguration
    {
        public int MaxConcurrentCalls { get; set; }

        public int MaxRetryCount { get; set; }

        public bool MessageAutoComplete { get; set; }
    }
}