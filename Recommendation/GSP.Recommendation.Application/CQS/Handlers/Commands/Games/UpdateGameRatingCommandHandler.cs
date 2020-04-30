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
    public class UpdateGameRatingCommandHandler : BaseVoidHandler<UpdateGameRatingCommand>
    {
        private readonly IMapper _mapper;

        private readonly IGameService _gameService;

        public UpdateGameRatingCommandHandler(ILogger<UpdateGameRatingCommand> logger, IMapper mapper, IGameService gameService)
            : base(logger)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        protected override async Task ExecuteAsync(UpdateGameRatingCommand request, CancellationToken ct)
        {
            UpdateGameRatingDto game = _mapper.Map<UpdateGameRatingDto>(request);
            await _gameService.UpdateRatingAsync(game, ct);
        }
    }
}