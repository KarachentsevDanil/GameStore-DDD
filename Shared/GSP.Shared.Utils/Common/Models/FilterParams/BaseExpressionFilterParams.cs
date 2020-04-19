using System;
using System.Linq.Expressions;

namespace GSP.Shared.Utils.Common.Models.FilterParams
{
    public abstract class BaseExpressionFilterParams<TEntity> : PaginationFilterParams
        where TEntity : class
    {
        public Expression<Func<TEntity, bool>> Expression { get; set; }
    }
}