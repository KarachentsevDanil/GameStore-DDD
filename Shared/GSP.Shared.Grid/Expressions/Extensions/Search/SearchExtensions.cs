using GSP.Shared.Grid.Expressions.Filters.Constants;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Expressions.Extensions.Search
{
    public static class SearchExtensions
    {
        public static Expression<Func<TEntity, bool>> GetSearchExpression<TEntity>(this IGrid<TEntity> grid)
        {
            if (string.IsNullOrEmpty(grid.Search?.Term) || !grid.Search.SearchFields.Any())
            {
                return default;
            }

            var expression = GenerateExpression<TEntity>(grid.Search.SearchFields[0], grid.Search.Term);

            for (int i = 1; i < grid.Search.SearchFields.Count; i++)
            {
                var searchExpression = GenerateExpression<TEntity>(grid.Search.SearchFields[i], grid.Search.Term);
                expression = expression.Or(searchExpression);
            }

            return expression;
        }

        private static Expression<Func<TEntity, bool>> GenerateExpression<TEntity>(string property, string term)
        {
            var queryTemplate = string.Format(
                CultureInfo.InvariantCulture,
                TextFilterConstants.ContainsLinqQuery,
                property,
                term);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(queryTemplate);
        }
    }
}