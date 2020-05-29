using GSP.Shared.Grid.Expressions.Contracts;
using GSP.Shared.Grid.Expressions.Extensions.Search;
using GSP.Shared.Grid.Expressions.Filters.Strategies.Stores.Contracts;
using GSP.Shared.Grid.Grids;
using GSP.Shared.Grid.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Expressions
{
    public class GridExpressionGenerator<TEntity> : IGridExpressionGenerator<TEntity>
    {
        private readonly IFilterExpressionGeneratorStore<TEntity> _filterStore;

        public GridExpressionGenerator(IFilterExpressionGeneratorStore<TEntity> filterStore)
        {
            _filterStore = filterStore;
        }

        public Expression<Func<TEntity, bool>> GetGridExpression(BaseGrid<TEntity> grid)
        {
            var expression = PredicateHelper.True<TEntity>();

            var customFilterExpression = grid.GetCustomFilterExpression();
            if (customFilterExpression != null)
            {
                expression = expression.And(customFilterExpression);
            }

            var searchExpression = grid.GetSearchExpression();
            if (searchExpression != null)
            {
                expression = expression.And(searchExpression);
            }

            foreach (var filter in grid.Filters.Where(q => q.HasSelectedData))
            {
                var filterExpression = _filterStore.FilterExpressionGeneratorStrategies[filter.Type].GetFilterLinqExpression(filter);
                if (filterExpression != null)
                {
                    expression = expression.And(filterExpression);
                }
            }

            return expression;
        }
    }
}