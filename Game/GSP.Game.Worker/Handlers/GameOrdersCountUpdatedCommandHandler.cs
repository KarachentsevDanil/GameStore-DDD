using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Worker.Commands;
using GSP.Shared.Utils.Common.Extensions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.Game.Worker.Handlers
{
    public class GameOrdersCountUpdatedCommandHandler : ICommandHandler<GameOrdersCountUpdatedCommand>
    {
        private readonly IGameService _gameService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public GameOrdersCountUpdatedCommandHandler(IGameService gameService, IMapper mapper, ILogger logger)
        {
            _gameService = gameService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(GameOrdersCountUpdatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(GameOrdersCountUpdatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            UpdateGameOrdersCountDto itemDto = _mapper.Map<UpdateGameOrdersCountDto>(command);

            await _gameService.UpdateOrdersCountAsync(itemDto);
        }
    }
}