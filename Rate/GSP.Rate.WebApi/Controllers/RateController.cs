using GSP.Rate.Application.CQS.Commands.Rates;
using GSP.Rate.Application.CQS.Queries.Rates;
using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Rate.Application.UseCases.Exceptions;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using GSP.Shared.Utils.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static GSP.Shared.Utils.WebApi.Helpers.ActionResultHelper;

namespace GSP.Rate.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="command">
        /// <see cref="CreateRateCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="GetRateDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody]CreateRateCommand command)
        {
            try
            {
                command.AccountId = User.GetUserId();
                GetRateDto item = await _mediator.Send(command);
                return CreatedAt(item);
            }
            catch (RateAlreadyExistsException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <param name="command">
        /// <see cref="UpdateRateCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="GetRateDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Item doesn't exist</response>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(long id, [FromBody]UpdateRateCommand command)
        {
            try
            {
                command.Id = id;
                command.AccountId = User.GetUserId();
                GetRateDto item = await _mediator.Send(command);
                return Ok(item);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (AccessToItemForbiddenException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="query">
        /// <see cref="GetRateListQuery"/>
        /// </param>
        /// <returns>
        /// <see cref="GetRateDto"/>
        /// </returns>
        [HttpGet("paged")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetPagedList([FromQuery]GetRateListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
