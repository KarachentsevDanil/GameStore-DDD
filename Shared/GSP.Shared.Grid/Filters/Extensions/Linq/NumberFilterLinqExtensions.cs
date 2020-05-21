using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions.Linq
{
    public static class NumberFilterLinqExtensions
    {
        public static Expression<Func<TEntity, bool>> GetNumberFilterLinqExpression<TEntity>(this ILinqFilter<TEntity> gridFilter)
        {
            if (gridFilter.NumberFilterOption == NumberFilterOption.Between)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    NumberFilterConstants.NumberBetweenLinqQuery,
                    gridFilter.PropertyName);

                return DynamicExpressionHelper.ParseLambda<TEntity, bool>(betweenQuery, gridFilter.FirstOperand, gridFilter.SecondOperand);
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                NumberFilterConstants.NumberQuery,
                gridFilter.PropertyName,
                gridFilter.NumberFilterOption.Value.GetNumberOperator(),
                gridFilter.Value);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetNumberOperator(this NumberFilterOption numberFilterOption)
        {
            switch (numberFilterOption)
            {
                case NumberFilterOption.Equals:
                    return NumberFilterConstants.EqualsLinqOperator;

                case NumberFilterOption.DoesNotEqual:
                    return NumberFilterConstants.DoesNotEqualLinqOperator;

                case NumberFilterOption.GreaterThan:
                    return NumberFilterConstants.GreaterThanOperator;

                case NumberFilterOption.GreaterThanOrEqual:
                    return NumberFilterConstants.GreaterThanOrEqualsOperator;

                case NumberFilterOption.LessThan:
                    return NumberFilterConstants.LessThanOperator;

                case NumberFilterOption.LessThanOrEqual:
                    return NumberFilterConstants.LessThanOrEqualsOperator;

                default:
                    throw new ArgumentOutOfRangeException(nameof(numberFilterOption), numberFilterOption, null);
            }
        }
    }
}