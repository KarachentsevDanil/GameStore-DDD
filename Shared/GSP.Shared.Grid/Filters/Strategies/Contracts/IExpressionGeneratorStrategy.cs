using GSP.Shared.Grid.Filters.Contracts;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Strategies.Contracts
{
    public interface IExpressionGeneratorStrategy<TEntity>
    {
        Expression<Func<TEntity, bool>> GetFilterLinqExpression(IFilter<TEntity> gridFilter);
    }
}