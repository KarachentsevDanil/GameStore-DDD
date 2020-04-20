using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Commands.Games
{
    public class UpdateGameOrdersCountCommandHandler : BaseResponseHandler<UpdateGameOrdersCountCommand, GetGameDto>
    {
        private readonly IGameService _service;

        public UpdateGameOrdersCountCommandHandler(
            ILogger<UpdateGameOrdersCountCommand> logger,
            IGameService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<GetGameDto> ExecuteAsync(UpdateGameOrdersCountCommand request, CancellationToken ct)
        {
            return await _service.UpdateOrdersCountAsync(new UpdateGameOrdersCountDto(request.Id, request.OrdersCount), ct);
        }
    }
}