using GSP.Shared.Grid.Models.Filters;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Expressions.Filters.Strategies.Contracts
{
    public interface IExpressionGeneratorStrategy<TEntity>
    {
        Expression<Func<TEntity, bool>> GetFilterLinqExpression(Filter gridFilter);
    }
}