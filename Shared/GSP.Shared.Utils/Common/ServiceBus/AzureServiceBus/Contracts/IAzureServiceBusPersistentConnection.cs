using Microsoft.Azure.ServiceBus;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Contracts
{
    public interface IAzureServiceBusPersistentConnection
    {
        /// <summary>
        /// Creates a topic
        /// </summary>
        /// <param name="topicName"></param>
        ITopicClient CreateTopicClient(string topicName);

        /// <summary>
        /// Creates a subscription client
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        ISubscriptionClient CreateSubscriptionClient(string topicName, string subscriptionName);
    }
}