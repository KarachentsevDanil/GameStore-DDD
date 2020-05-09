using GSP.WepApi.Aggregator.Constants;
using GSP.WepApi.Aggregator.DTOs.Rates;
using Refit;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Api.Contracts
{
    public interface IRateApiClient
    {
        [Post("/api/rate")]
        Task<GetRateDto> CreateRateAsync(
            [Header(HeaderConstants.Authorization)] string authHeader,
            [Body]CreateRateDto rateDto);
    }
}