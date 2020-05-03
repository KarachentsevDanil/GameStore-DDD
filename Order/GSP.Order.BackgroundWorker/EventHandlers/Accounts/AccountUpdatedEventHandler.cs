using AutoMapper;
using GSP.Order.BackgroundWorker.Events.Accounts;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Order.BackgroundWorker.EventHandlers.Accounts
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
