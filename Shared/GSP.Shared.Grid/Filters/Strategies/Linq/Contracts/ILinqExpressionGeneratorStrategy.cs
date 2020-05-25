using GSP.Shared.Grid.Filters.Contracts;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Strategies.Linq.Contracts
{
    public interface ILinqExpressionGeneratorStrategy<TEntity>
    {
        Expression<Func<TEntity, bool>> GetFilterLinqExpression(ILinqFilter<TEntity> gridFilter);
    }
}