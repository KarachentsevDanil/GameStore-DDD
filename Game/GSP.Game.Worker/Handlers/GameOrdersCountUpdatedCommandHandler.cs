using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Worker.Commands;
using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.Game.Worker.Handlers
{
    public class GameOrdersCountUpdatedCommandHandler : ICommandHandler<GameOrdersCountUpdatedCommand>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public GameOrdersCountUpdatedCommandHandler(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(GameOrdersCountUpdatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(GameOrdersCountUpdatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            UpdateGameOrdersCountCommand updateOrderCount = _mapper.Map<UpdateGameOrdersCountCommand>(command);

            await _mediator.Send(updateOrderCount);
        }
    }
}