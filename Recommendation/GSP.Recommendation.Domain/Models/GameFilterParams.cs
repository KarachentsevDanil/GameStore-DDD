using GSP.Recommendation.Domain.Enums;
using GSP.Shared.Utils.Common.Models.FilterParams;

namespace GSP.Recommendation.Domain.Models
{
    public class GameFilterParams : PaginationFilterParams
    {
        public GameSortingType SortingType { get; set; }
    }
}