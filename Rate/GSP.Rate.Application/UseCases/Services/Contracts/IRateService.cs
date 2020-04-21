using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Rate.Domain.Models;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Application.UseCases.Services.Contracts
{
    public interface IRateService : IBaseService<GetRateDto, AddRateDto, UpdateRateDto>
    {
        ValueTask<double> GetAverageRatingByGameIdAsync(long gameId, CancellationToken ct = default);

        ValueTask<int> GetCountOfReviewByGameIdAsync(long gameId, CancellationToken ct = default);

        Task<PagedCollection<GetRateDto>> GetListByFilterParamsAsync(RateFilterParams filterParams, CancellationToken ct = default);
    }
}