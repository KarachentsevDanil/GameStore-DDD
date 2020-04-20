using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Commands.Games
{
    public class UpdateGameRatingCommandHandler : BaseResponseHandler<UpdateGameRatingCommand, GetGameDto>
    {
        private readonly IGameService _service;

        public UpdateGameRatingCommandHandler(
            ILogger<UpdateGameRatingCommand> logger,
            IGameService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<GetGameDto> ExecuteAsync(UpdateGameRatingCommand request, CancellationToken ct)
        {
            return await _service.UpdateRatingAsync(new UpdateGameRatingDto(request.Id, request.ReviewsCount, request.AverageRating), ct);
        }
    }
}