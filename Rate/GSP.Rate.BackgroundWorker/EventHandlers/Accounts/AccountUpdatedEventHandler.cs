using AutoMapper;
using GSP.Rate.BackgroundWorker.Events.Accounts;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Rate.BackgroundWorker.EventHandlers.Accounts
{
    public class AccountUpdatedEventHandler : IIntegrationEventHandler<AccountUpdatedEvent>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public AccountUpdatedEventHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(AccountUpdatedEvent @event)
        {
            UpdateAccountCommand command = _mapper.Map<UpdateAccountCommand>(@event);
            await _mediator.Send(command);
        }
    }
}
