using GSP.Shared.Utils.Application.CQS.Commands;
using GSP.Shared.Utils.Application.CQS.Queries;
using GSP.Shared.Utils.Application.UseCases.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static GSP.Shared.Utils.WebApi.Helpers.ActionResultHelper;

namespace GSP.Shared.Utils.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseCrudController
        <TGetItemDto, TCreateItemCommand, TUpdateItemCommand, TGetItemByIdQuery, TGetPagedListQuery> : ControllerBase
        where TGetItemDto : BaseGetItemDto
        where TCreateItemCommand : BaseCreateItemCommand<TGetItemDto>
        where TUpdateItemCommand : BaseUpdateItemCommand<TGetItemDto>
        where TGetItemByIdQuery : BaseGetByIdQuery<TGetItemDto>, new()
        where TGetPagedListQuery : BaseGetPagedListQuery<TGetItemDto>
    {
        protected BaseCrudController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// <see cref="TGetItemDto"/>
        /// </returns>
        /// <response code="404">Item doesn't exist</response>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(long id)
        {
            TGetItemByIdQuery query = new TGetItemByIdQuery
            {
                Id = id
            };

            TGetItemDto item = await Mediator.Send(query);

            return Ok(item);
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="command">
        /// <see cref="TCreateItemCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="TGetItemDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody]TCreateItemCommand command)
        {
            TGetItemDto item = await Mediator.Send(command);
            return CreatedAt(item);
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <param name="command">
        /// <see cref="TUpdateItemCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="TGetItemDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Item doesn't exist</response>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(long id, [FromBody]TUpdateItemCommand command)
        {
            command.Id = id;
            TGetItemDto item = await Mediator.Send(command);
            return Ok(item);
        }

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="query">
        /// <see cref="TGetPagedListQuery"/>
        /// </param>
        /// <returns>
        /// <see cref="TGetItemDto"/>
        /// </returns>
        [HttpGet("paged")]
        public virtual async Task<IActionResult> GetPagedList([FromQuery]TGetPagedListQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}