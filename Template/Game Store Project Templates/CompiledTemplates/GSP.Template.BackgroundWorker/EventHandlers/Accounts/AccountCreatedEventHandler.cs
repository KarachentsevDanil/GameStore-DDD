using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using $safeprojectname$.Events.Accounts;
using MediatR;
using System.Threading.Tasks;

namespace $safeprojectname$.EventHandlers.Accounts
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