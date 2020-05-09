using GSP.WepApi.Aggregator.Constants;
using GSP.WepApi.Aggregator.DTOs.Orders;
using Refit;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Api.Contracts
{
    public interface IOrderApiClient
    {
        [Get("/api/order")]
        Task<OrderDto> GetCurrentOrderAsync([Header(HeaderConstants.Authorization)] string authHeader);
    }
}