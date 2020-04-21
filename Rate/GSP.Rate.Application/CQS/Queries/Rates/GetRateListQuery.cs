using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Shared.Utils.Application.CQS.Queries;

namespace GSP.Rate.Application.CQS.Queries.Rates
{
    public class GetRateListQuery : BaseGetPagedListQuery<GetRateDto>
    {
        public long GameId { get; set; }
    }
}