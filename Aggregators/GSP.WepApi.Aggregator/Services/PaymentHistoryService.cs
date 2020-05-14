using GSP.WepApi.Aggregator.DTOs.Payments;
using GSP.WepApi.Aggregator.Extensions;
using GSP.WepApi.Aggregator.Services.Api.Contracts;
using GSP.WepApi.Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services
{
    public class PaymentHistoryService : IPaymentHistoryService
    {
        private readonly IPaymentHistoryApiClient _paymentHistoryApiClient;

        private readonly IOrderApiClient _orderApiClient;

        private readonly ILogger _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentHistoryService(
            ILogger<RateService> logger,
            IHttpContextAccessor httpContextAccessor,
            IPaymentHistoryApiClient paymentHistoryApiClient,
            IOrderApiClient orderApiClient)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _paymentHistoryApiClient = paymentHistoryApiClient;
            _orderApiClient = orderApiClient;
        }

        public async Task<GetPaymentHistoryDto> CreateAsync(CreatePaymentHistoryDto dto)
        {
            var authHeader = _httpContextAccessor.GetAuthorizationHeaderOrDefault();

            var order = await _orderApiClient.GetCurrentOrderAsync(authHeader);

            dto.OrderId = order.Id;

            return await _paymentHistoryApiClient.CreatePaymentHistoryAsync(authHeader, dto);
        }
    }
}