using GSP.WepApi.Aggregator.DTOs.Recommendations;
using GSP.WepApi.Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        /// <summary>
        /// Get recommended games
        /// </summary>
        /// <param name="query">
        /// <see cref="GetRecommendedGamesQueryDto"/>
        /// </param>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetRecommendedGames([FromQuery] GetRecommendedGamesQueryDto query)
        {
            return Ok(await _recommendationService.GetRecommendedGamesAsync(query));
        }
    }
}