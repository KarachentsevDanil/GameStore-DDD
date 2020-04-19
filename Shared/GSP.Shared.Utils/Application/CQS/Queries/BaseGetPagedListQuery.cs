using GSP.Shared.Utils.Common.Constants;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using MediatR;

namespace GSP.Shared.Utils.Application.CQS.Queries
{
    public class BaseGetPagedListQuery<TResponse> : IRequest<PagedCollection<TResponse>>
        where TResponse : class
    {
        public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;

        public int PageNumber { get; set; } = PaginationConstants.DefaultPageNumber;

        public PaginationFilterParams ToPaginationFilterParams()
        {
            return new PaginationFilterParams
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        }
    }
}