using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Domain.Account.Enums;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GSP.Game.WebApi.Controllers
{
    [Authorize(Roles = nameof(UserRoleType.Admin))]
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