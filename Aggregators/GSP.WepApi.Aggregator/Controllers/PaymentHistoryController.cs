using GSP.WepApi.Aggregator.DTOs.Payments;
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
    public class PaymentHistoryController : ControllerBase
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public PaymentHistoryController(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        /// <summary>
        /// Add payment history
        /// </summary>
        /// <param name="command">
        /// <see cref="CreatePaymentHistoryDto"/>
        /// </param>
        /// <returns>
        /// <see cref="GetPaymentHistoryDto"/>
        /// </returns>
        /// <response code="400">Validation failed</response>
        /// <response code="400">Payment method doesn't exists</response>
        /// <response code="400">Account doesn't have access to payment method</response>
        /// <response code="400">Cvv is wrong</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreatePaymentHistoryDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreatePaymentHistoryDto command)
        {
            var response = await _paymentHistoryService.CreateAsync(command);
            return CreatedAt(response);
        }
    }
}