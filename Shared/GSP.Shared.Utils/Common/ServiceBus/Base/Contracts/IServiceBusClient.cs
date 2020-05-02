using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.ServiceBus.Base.Contracts
{
    public interface IServiceBusClient
    {
        /// <summary>
        /// Publishes an event of <typeparamref name="T"/> to the Service Bus
        /// </summary>
        /// <typeparam name="T">Type of an event</typeparam>
        /// <param name="busEvent">Event which will be sent to the service bus</param>
        /// <param name="topicName">Topic name</param>
        Task PublishAsync<T>(T busEvent, string topicName);

        /// <summary>
        /// Publishes an event of <typeparamref name="T"/> to the Service Bus
        /// </summary>
        /// <typeparam name="T">Type of an event</typeparam>
        /// <param name="busEvent">Event which will be sent to the service bus</param>
        /// <param name="label">Label which will be added to a message</param>
        /// <param name="topicName">Topic name</param>
        Task PublishAsync<T>(T busEvent, string label, string topicName);
    }
}