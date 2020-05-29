using GSP.Shared.Grid.Expressions.Filters.Strategies.Contracts;
using GSP.Shared.Grid.Models.Filters.Enums;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Expressions.Filters.Strategies.Stores.Contracts
{
    public interface IFilterExpressionGeneratorStore<TEntity>
    {
        IDictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>> FilterExpressionGeneratorStrategies { get; }
    }
}