using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Shared.Utils.Common.ServiceBus.Base.Contracts
{
    public interface IServiceBusSubscriptionClient<TEvent, TEventHandler>
        where TEvent : IntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>
    {
        /// <summary>
        /// Register event handler
        /// </summary>
        void RegisterMessageHandler();
    }
}