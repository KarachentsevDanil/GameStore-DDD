using GSP.Recommendation.Application.CQS.Queries.Recommendations;
using GSP.Shared.Utils.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GSP.Recommendation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecommendationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get recommended game ids
        /// </summary>
        /// <param name="query">
        /// <see cref="GetRecommendedGamesQuery"/>
        /// </param>
        [HttpGet]
        public async Task<IActionResult> GetRecommendedGames([FromQuery] GetRecommendedGamesQuery query)
        {
            query.AccountId = User?.GetUserId();
            return Ok(await _mediator.Send(query));
        }
    }
}