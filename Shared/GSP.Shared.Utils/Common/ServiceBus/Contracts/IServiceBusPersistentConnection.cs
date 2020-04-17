using Microsoft.Azure.ServiceBus;

namespace GSP.Shared.Utils.Common.ServiceBus.Contracts
{
    public interface IServiceBusPersistentConnection
    {
        /// <summary>
        /// Creates a topic
        /// </summary>
        /// <param name="topicName"></param>
        ITopicClient CreateTopicClient(string topicName);
    }
}