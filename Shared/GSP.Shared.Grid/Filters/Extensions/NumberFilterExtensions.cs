using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions
{
    public static class NumberFilterExtensions
    {
        public static Expression<Func<TEntity, bool>> GetNumberFilterExpression<TEntity>(this IGridFilter<TEntity> gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                GridNumberFilterConstants.NumberQuery,
                gridFilter.PropertyName,
                gridFilter.NumberFilterOption.GetNumberOperator(),
                gridFilter.Value);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetNumberOperator(this NumberFilterOption numberFilterOption)
        {
            switch (numberFilterOption)
            {
                case NumberFilterOption.Equals:
                    return GridNumberFilterConstants.EqualsOperator;
                case NumberFilterOption.DoesNotEqual:
                    return GridNumberFilterConstants.DoesNotEqualOperator;
                default:
                    throw new ArgumentOutOfRangeException(nameof(numberFilterOption), numberFilterOption, null);
            }
        }
    }
}