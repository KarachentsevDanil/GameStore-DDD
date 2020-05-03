using AutoMapper;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.BackgroundWorker.Events.Games;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using System.Threading.Tasks;

namespace GSP.Order.BackgroundWorker.EventHandlers.Games
{
    public class GameCreatedEventHandler : IIntegrationEventHandler<GameCreatedEvent>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public GameCreatedEventHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(GameCreatedEvent @event)
        {
            CreateGameCommand command = _mapper.Map<CreateGameCommand>(@event);
            await _mediator.Send(command);
        }
    }
}
