using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Strategies.Contracts;
using GSP.Shared.Grid.Filters.Strategies.Stores.Contracts;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Filters.Strategies.Stores
{
    public class FilterExpressionGeneratorStore<TEntity> : IFilterExpressionGeneratorStore<TEntity>
    {
        public FilterExpressionGeneratorStore()
        {
            InitializeExpressionGenerator();
        }

        public IDictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>> FilterExpressionGeneratorStrategies =>
            new Dictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>>();

        private void InitializeExpressionGenerator()
        {
            FilterExpressionGeneratorStrategies.Add(GridFilterType.Boolean, new BooleanExpressionGeneratorStrategy<TEntity>());
            FilterExpressionGeneratorStrategies.Add(GridFilterType.Date, new DateExpressionGeneratorStrategy<TEntity>());
            FilterExpressionGeneratorStrategies.Add(GridFilterType.List, new ListExpressionGeneratorStrategy<TEntity>());
            FilterExpressionGeneratorStrategies.Add(GridFilterType.Number, new NumberExpressionGeneratorStrategy<TEntity>());
            FilterExpressionGeneratorStrategies.Add(GridFilterType.Text, new TextExpressionGeneratorStrategy<TEntity>());
        }
    }
}