using GSP.Shared.Utils.Common.Constants;

namespace GSP.Shared.Utils.Common.Models.FilterParams
{
    public class PaginationFilterParams
    {
        public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;

        public int PageNumber { get; set; } = PaginationConstants.DefaultPageNumber;
    }
}