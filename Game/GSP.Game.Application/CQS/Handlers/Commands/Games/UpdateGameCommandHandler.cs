using AutoMapper;
using FluentValidation;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Commands.Games
{
    public class UpdateGameCommandHandler : BaseValidationResponseHandler<UpdateGameCommand, GetGameDto>
    {
        private readonly IMapper _mapper;

        private readonly IGameService _developerStudioService;

        public UpdateGameCommandHandler(
            AbstractValidator<UpdateGameCommand> validator,
            ILogger<UpdateGameCommand> logger,
            IMapper mapper,
            IGameService developerStudioService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _developerStudioService = developerStudioService;
        }

        protected override async Task<GetGameDto> ExecuteAsync(UpdateGameCommand request, CancellationToken ct)
        {
            return await _developerStudioService.UpdateAsync(_mapper.Map<UpdateGameDto>(request), ct);
        }
    }
}