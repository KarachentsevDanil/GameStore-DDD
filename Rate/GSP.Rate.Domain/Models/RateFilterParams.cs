using GSP.Rate.Domain.Entities;
using GSP.Shared.Utils.Common.Models.FilterParams;

namespace GSP.Rate.Domain.Models
{
    public class RateFilterParams : BaseExpressionFilterParams<RateBase>
    {
        public long GameId { get; set; }
    }
}