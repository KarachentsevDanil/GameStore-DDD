using GSP.Payment.Application.CQS.Commands.PaymentMethods;
using GSP.Payment.Application.CQS.Queries.PaymentMethods;
using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
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
    public class PaymentMethodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentMethodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add payment method
        /// </summary>
        /// <param name="command">
        /// <see cref="CreatePaymentMethodCommand"/>
        /// </param>
        /// <returns>
        /// <see cref="GetPaymentMethodDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentMethodCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAt(response);
        }

        /// <summary>
        /// Get payment methods for account
        /// </summary>
        /// <returns>
        /// <see cref="GetPaymentMethodDto"/>
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetPaymentMethodsQuery query = new GetPaymentMethodsQuery(User.GetUserId());
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
