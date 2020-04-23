using GSP.Order.Application.CQS.Queries.Games;
using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace GSP.Order.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get account games
        /// </summary>
        /// <returns>
        /// <see cref="GetGameDto"/>
        /// </returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetOrders()
        {
            IImmutableList<GetGameDto> games = await _mediator.Send(new GetGamesByAccountQuery(User.GetUserId()));
            return Ok(games);
        }
    }
}