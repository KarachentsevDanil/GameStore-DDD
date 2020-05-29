using FluentValidation;
using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Domain.Grids;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Grids;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Games
{
    public class GetGameGridQueryHandler
        : BaseValidationResponseHandler<GetGameGridQuery, GridModel>
    {
        private readonly IGameService _service;

        public GetGameGridQueryHandler(
            ILogger<GetGameGridQuery> logger,
            IGameService service,
            IValidator<GameGrid> gridValidator)
            : base(gridValidator, logger)
        {
            _service = service;
        }

        protected override async Task<GridModel> ExecuteAsync(GetGameGridQuery request, CancellationToken ct)
        {
            return await _service.GetGridAsync(request.GameBaseGrid, ct);
        }

        protected override object GetObjectToValidate(GetGameGridQuery request)
        {
            return request.GameBaseGrid;
        }
    }
}