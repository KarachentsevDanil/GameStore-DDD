using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Domain.Account.Enums;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

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

        /// <summary>
        /// Get games by query
        /// </summary>
        /// <param name="query">
        /// <see cref="GetGamePagedListQuery"/>
        /// </param>
        /// <returns>
        /// <see cref="GetGameDto"/>
        /// </returns>
        [HttpPost("grid")]
        [ProducesResponseType(typeof(GetGameDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGamesGrid([FromBody] GetGameGridQuery query)
        {
            var games = await Mediator.Send(query);
            return Ok(games);
        }
    }
}