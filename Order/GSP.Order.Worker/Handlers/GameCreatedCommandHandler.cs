using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.Worker.Commands;
using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.Order.Worker.Handlers
{
    public class GameCreatedCommandHandler : ICommandHandler<GameCreatedCommand>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public GameCreatedCommandHandler(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(GameCreatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(GameCreatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            CreateGameCommand createGameCommand = _mapper.Map<CreateGameCommand>(command);

            await _mediator.Send(createGameCommand);
        }
    }
}