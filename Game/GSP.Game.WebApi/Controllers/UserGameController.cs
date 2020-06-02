using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GSP.Game.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserGameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserGameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get game by id
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// <see cref="GetGameDto"/>
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetGameDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGames(long id)
        {
            var game = await _mediator.Send(new GetGameByIdQuery(id));
            return Ok(game);
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
        [HttpGet("list")]
        [ProducesResponseType(typeof(GetGameDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGames([FromQuery] GetGamePagedListQuery query)
        {
            var games = await _mediator.Send(query);
            return Ok(games);
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
            var games = await _mediator.Send(query);
            return Ok(games);
        }
    }
}