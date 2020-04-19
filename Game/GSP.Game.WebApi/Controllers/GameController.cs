using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;

namespace GSP.Game.WebApi.Controllers
{
    public class GameController
        : BaseCrudController<
            GetGameDto,
            CreateGameCommand,
            UpdateGameCommand,
            GetGameByIdQuery,
            GetGamePagedListQuery>
    {
        public GameController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}