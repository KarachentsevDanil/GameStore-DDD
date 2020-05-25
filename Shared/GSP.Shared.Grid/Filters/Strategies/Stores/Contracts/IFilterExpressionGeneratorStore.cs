using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Strategies.Contracts;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Filters.Strategies.Stores.Contracts
{
    public interface IFilterExpressionGeneratorStore<TEntity>
    {
        IDictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>> FilterExpressionGeneratorStrategies { get; }
    }
}