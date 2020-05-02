using System.Threading.Tasks;
using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Shared.Utils.Common.ServiceBus.Base.Contracts
{
    public interface IServiceBusClient
    {
        /// <summary>
        /// Publishes an event of <typeparamref name="TEvent"/> to the Service Bus
        /// </summary>
        /// <typeparam name="TEvent">Type of an event</typeparam>
        /// <param name="busEvent">Event which will be sent to the service bus</param>
        /// <param name="topicName">Topic name</param>
        Task PublishAsync<TEvent>(TEvent busEvent, string topicName)
            where TEvent : IntegrationEvent;

        /// <summary>
        /// Publishes an event of <typeparamref name="TEvent"/> to the Service Bus
        /// </summary>
        /// <typeparam name="TEvent">Type of an event</typeparam>
        /// <param name="busEvent">Event which will be sent to the service bus</param>
        /// <param name="label">Label which will be added to a message</param>
        /// <param name="topicName">Topic name</param>
        Task PublishAsync<TEvent>(TEvent busEvent, string label, string topicName)
            where TEvent : IntegrationEvent;
    }
}