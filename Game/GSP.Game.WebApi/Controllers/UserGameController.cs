using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GSP.Game.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserGameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserGameController(IMediator mediator)
        {
            _mediator = mediator;
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
        [HttpGet]
        [ProducesResponseType(typeof(GetGameDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGames([FromQuery] GetGamePagedListQuery query)
        {
            var games = await _mediator.Send(query);
            return Ok(games);
        }
    }
}