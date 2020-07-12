using GSP.Shared.Utils.Common.EventBus.Base.Models;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.EventBus.Base.Contracts
{
    public interface IIntegrationEventHandler<in TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
}