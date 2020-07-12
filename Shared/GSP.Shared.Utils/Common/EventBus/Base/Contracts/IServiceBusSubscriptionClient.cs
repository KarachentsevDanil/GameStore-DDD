using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Shared.Utils.Common.EventBus.Base.Contracts
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