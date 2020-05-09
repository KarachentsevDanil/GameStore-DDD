using GSP.WepApi.Aggregator.Constants;
using GSP.WepApi.Aggregator.DTOs.Payments;
using Refit;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Api.Contracts
{
    public interface IPaymentHistoryApiClient
    {
        [Post("/api/paymenthistory")]
        Task<GetPaymentHistoryDto> CreatePaymentHistoryAsync(
            [Header(HeaderConstants.Authorization)] string authHeader,
            [Body]CreatePaymentHistoryDto paymentHistoryDto);
    }
}