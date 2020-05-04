using AutoMapper;
using GSP.Rate.BackgroundWorker.Events.Accounts;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Rate.BackgroundWorker.EventHandlers.Accounts
{
    public class AccountCreatedEventHandler : IIntegrationEventHandler<AccountCreatedEvent>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public AccountCreatedEventHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(AccountCreatedEvent @event)
        {
            CreateAccountCommand command = _mapper.Map<CreateAccountCommand>(@event);
            await _mediator.Send(command);
        }
    }
}
