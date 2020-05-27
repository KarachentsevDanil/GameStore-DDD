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

        public IDictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>> FilterExpressionGeneratorStrategies { get; set; }

        private void InitializeExpressionGenerator()
        {
            FilterExpressionGeneratorStrategies =
                new Dictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>>
                {
                    { GridFilterType.Boolean, new BooleanExpressionGeneratorStrategy<TEntity>() },
                    { GridFilterType.Date, new DateExpressionGeneratorStrategy<TEntity>() },
                    { GridFilterType.List, new ListExpressionGeneratorStrategy<TEntity>() },
                    { GridFilterType.Number, new NumberExpressionGeneratorStrategy<TEntity>() },
                    { GridFilterType.Text, new TextExpressionGeneratorStrategy<TEntity>() }
                };
        }
    }
}