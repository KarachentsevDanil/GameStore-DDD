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
    public class GameRatingUpdatedCommandHandler : ICommandHandler<GameRatingUpdatedCommand>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public GameRatingUpdatedCommandHandler(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(GameRatingUpdatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(GameRatingUpdatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            UpdateGameRatingCommand updateGameRating = _mapper.Map<UpdateGameRatingCommand>(command);

            await _mediator.Send(updateGameRating);
        }
    }
}