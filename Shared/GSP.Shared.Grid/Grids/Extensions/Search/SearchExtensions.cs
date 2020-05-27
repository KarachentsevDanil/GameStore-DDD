using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids.Extensions.Search
{
    public static class SearchExtensions
    {
        public static Expression<Func<TEntity, bool>> GetSearchExpression<TEntity>(this IGrid<TEntity> grid)
        {
            if (string.IsNullOrEmpty(grid.Search?.Term))
            {
                return default;
            }

            var expression = PredicateHelper.True<TEntity>();

            foreach (var property in grid.Search.SearchFields)
            {
                var query = string.Format(CultureInfo.InvariantCulture, TextFilterConstants.ContainsLinqQuery, property, grid.Search.Term);
                expression = expression.Or(DynamicExpressionHelper.ParseLambda<TEntity, bool>(query));
            }

            return expression;
        }
    }
}