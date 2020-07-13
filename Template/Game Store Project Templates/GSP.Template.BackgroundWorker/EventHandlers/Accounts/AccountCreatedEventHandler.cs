using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Template.BackgroundWorker.Events.Accounts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Template.BackgroundWorker.EventHandlers.Accounts
{
    public class AccountCreatedEventHandler : IIntegrationEventHandler<AccountCreatedEvent>
    {
        private readonly IMediator _mediator;

        public AccountCreatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(AccountCreatedEvent @event)
        {
            await _mediator.Send(@event);
        }
    }
}