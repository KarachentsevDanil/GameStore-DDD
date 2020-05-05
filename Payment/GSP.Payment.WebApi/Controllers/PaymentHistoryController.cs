using GSP.Payment.Application.CQS.Commands.PaymentHistories;
using GSP.Payment.Application.CQS.Queries.PaymentHistories;
using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Payment.Application.UseCases.Exceptions;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using GSP.Shared.Utils.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static GSP.Shared.Utils.WebApi.Helpers.ActionResultHelper;

namespace GSP.Payment.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PaymentHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add payment history
        /// </summary>
        /// <param name="command">
        /// <see cref="CreatePaymentHistoryCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="GetPaymentHistoryDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="400">Payment method doesn't exists</response>
        /// <response code="400">Account doesn't have access to payment method</response>
        /// <response code="400">Cvv is wrong</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentHistoryCommand command)
        {
            command.AccountId = User.GetUserId();
            var response = await _mediator.Send(command);
            return CreatedAt(response);
        }

        /// <summary>
        /// Get payment histories
        /// </summary>
        /// <param name="query">
        /// <see cref="GetPaymentHistoriesQuery"/>
        /// </param>
        /// <returns>
        /// <see cref="GetPaymentHistoryDto"/>
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPaymentHistoriesQuery query)
        {
            query.AccountId = User.GetUserId();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
