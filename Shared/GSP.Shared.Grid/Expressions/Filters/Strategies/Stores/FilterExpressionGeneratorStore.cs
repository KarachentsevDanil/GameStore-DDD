using GSP.Shared.Grid.Expressions.Filters.Strategies.Contracts;
using GSP.Shared.Grid.Expressions.Filters.Strategies.Stores.Contracts;
using GSP.Shared.Grid.Models.Filters.Enums;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Expressions.Filters.Strategies.Stores
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