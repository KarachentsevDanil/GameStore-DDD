using GSP.WepApi.Aggregator.DTOs.Payments;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Contracts
{
    public interface IPaymentHistoryService
    {
        Task<GetPaymentHistoryDto> CreateAsync(CreatePaymentHistoryDto dto);
    }
}