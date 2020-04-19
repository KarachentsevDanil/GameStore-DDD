using GSP.Shared.Utils.Common.Constants;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Utils.Common.Models.FilterParams
{
    public abstract class BaseExpressionFilterParams<TEntity>
        where TEntity : class
    {
        public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;

        public int PageNumber { get; set; } = PaginationConstants.DefaultPageNumber;

        public Expression<Func<TEntity, bool>> Expression { get; set; }
    }
}