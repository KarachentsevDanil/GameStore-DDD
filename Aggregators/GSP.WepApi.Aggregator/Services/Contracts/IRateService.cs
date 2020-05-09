using GSP.WepApi.Aggregator.DTOs.Rates;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Contracts
{
    public interface IRateService
    {
        Task<GetRateDto> CreateAsync(CreateRateDto rate);
    }
}