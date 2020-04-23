using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Application.CQS.Queries.Orders;
using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Order.Application.UseCases.Exceptions;
using GSP.Shared.Utils.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Threading.Tasks;
using static GSP.Shared.Utils.WebApi.Helpers.ActionResultHelper;

namespace GSP.Order.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create new order
        /// </summary>
        /// <returns>
        /// <see cref="GetOrderDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="400">Account already has uncompleted order</response>
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            try
            {
                GetOrderDto order = await _mediator.Send(new CreateOrderCommand(User.GetUserId()));
                return CreatedAt(order);
            }
            catch (AccountHasUncompletedOrderException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Complete current order
        /// </summary>
        /// <returns>
        /// <see cref="GetOrderDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="400">Account doesn't have active order</response>
        /// <response code="400">Order doesn't have games</response>
        [HttpPut]
        public async Task<IActionResult> Complete()
        {
            try
            {
                GetOrderDto order = await _mediator.Send(new CompleteOrderCommand(User.GetUserId()));
                return Ok(order);
            }
            catch (UserDoesNotHaveActiveOrderException)
            {
                return BadRequest();
            }
            catch (OrderDoesNotHaveGamesException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add game to order
        /// </summary>
        /// <param name="command">
        /// <see cref="AddOrderToGameCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="GetOrderDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="400">Account doesn't have order</response>
        /// <response code="400">Account already has game</response>
        [HttpPut("addgame")]
        public async Task<IActionResult> AddGameToOrder([FromBody] AddOrderToGameCommand command)
        {
            try
            {
                command.AccountId = User.GetUserId();
                GetOrderDto order = await _mediator.Send(command);
                return Ok(order);
            }
            catch (UserDoesNotHaveActiveOrderException)
            {
                return BadRequest();
            }
            catch (AccountAlreadyHasGameException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove game from order
        /// </summary>
        /// <param name="command">
        /// <see cref="RemoveOrderToGameCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="GetOrderDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="400">Account doesn't have order</response>
        /// <response code="400">Order doesn't game</response>
        [HttpPut("removegame")]
        public async Task<IActionResult> RemoveGameFromOrder([FromBody] RemoveOrderToGameCommand command)
        {
            try
            {
                command.AccountId = User.GetUserId();
                GetOrderDto order = await _mediator.Send(command);
                return Ok(order);
            }
            catch (UserDoesNotHaveActiveOrderException)
            {
                return BadRequest();
            }
            catch (AccountDoesNotHaveGameException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get current order
        /// </summary>
        /// <returns>
        /// <see cref="GetOrderDto"/>
        /// </returns>
        /// <response code="404">Account doesn't have active order</response>
        [HttpGet]
        public async Task<IActionResult> GetCurrentOrder()
        {
            try
            {
                GetOrderDto order = await _mediator.Send(new GetOrderByAccountQuery(User.GetUserId()));
                return Ok(order);
            }
            catch (UserDoesNotHaveActiveOrderException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get account orders
        /// </summary>
        /// <returns>
        /// <see cref="GetOrderDto"/>
        /// </returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetOrders()
        {
            IImmutableList<GetOrderDto> orders = await _mediator.Send(new GetOrdersByAccountQuery(User.GetUserId()));
            return Ok(orders);
        }
    }
}