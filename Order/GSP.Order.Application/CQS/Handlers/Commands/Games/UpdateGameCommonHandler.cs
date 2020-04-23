using AutoMapper;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Commands.Games
{
    public class UpdateGameCommonHandler : BaseResponseHandler<UpdateGameCommand, GetGameDto>
    {
        private readonly IMapper _mapper;

        private readonly IGameService _gameService;

        public UpdateGameCommonHandler(
            ILogger<UpdateGameCommand> logger,
            IMapper mapper,
            IGameService gameService)
            : base(logger)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        protected override async Task<GetGameDto> ExecuteAsync(UpdateGameCommand request, CancellationToken ct)
        {
            UpdateGameDto accountDto = _mapper.Map<UpdateGameDto>(request);
            return await _gameService.UpdateAsync(accountDto, ct);
        }
    }
}