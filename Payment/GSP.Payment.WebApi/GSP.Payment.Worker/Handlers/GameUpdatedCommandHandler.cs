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
    public class GameUpdatedCommandHandler : ICommandHandler<GameUpdatedCommand>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public GameUpdatedCommandHandler(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(GameUpdatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(GameUpdatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            UpdateGameCommand updateGameCommand = _mapper.Map<UpdateGameCommand>(command);

            await _mediator.Send(updateGameCommand);
        }
    }
}