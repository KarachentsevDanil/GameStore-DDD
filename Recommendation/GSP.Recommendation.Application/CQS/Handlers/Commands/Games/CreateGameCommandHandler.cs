using AutoMapper;
using GSP.Recommendation.Application.CQS.Commands.Games;
using GSP.Recommendation.Application.UseCases.DTOs.Games;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.CQS.Handlers.Commands.Games
{
    public class CreateGameCommandHandler : BaseVoidHandler<CreateGameCommand>
    {
        private readonly IMapper _mapper;

        private readonly IGameService _gameService;

        public CreateGameCommandHandler(ILogger<CreateGameCommand> logger, IMapper mapper, IGameService gameService)
            : base(logger)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        protected override async Task ExecuteAsync(CreateGameCommand request, CancellationToken ct)
        {
            AddGameDto game = _mapper.Map<AddGameDto>(request);
            await _gameService.AddAsync(game, ct);
        }
    }
}