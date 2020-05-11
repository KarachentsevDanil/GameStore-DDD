using GSP.WepApi.Aggregator.DTOs.Rates;
using GSP.WepApi.Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using static GSP.Shared.Utils.WebApi.Helpers.ActionResultHelper;

namespace GSP.WepApi.Aggregator.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        /// <summary>
        /// Add rate item
        /// </summary>
        /// <param name="rate">
        /// <see cref="CreateRateDto"/>
        /// </param>
        /// <returns>
        /// <see cref="GetRateDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        [HttpPost]
        [ProducesResponseType(typeof(GetRateDto), (int)HttpStatusCode.Created)]
        public virtual async Task<IActionResult> Create([FromBody]CreateRateDto rate)
        {
            var createdRate = await _rateService.CreateAsync(rate);
            return CreatedAt(createdRate);
        }
    }
}