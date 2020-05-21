using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Extensions.Sql
{
    public static class NumberFilterSqlExtensions
    {
        public static string GetNumberFilterSqlQuery(this ISqlFilter gridFilter)
        {
            if (gridFilter.NumberFilterOption == NumberFilterOption.Between)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    NumberFilterConstants.NumberBetweenSqlQuery,
                    gridFilter.PropertyName,
                    gridFilter.FirstOperand,
                    gridFilter.SecondOperand);

                return betweenQuery;
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                NumberFilterConstants.NumberQuery,
                gridFilter.PropertyName,
                gridFilter.NumberFilterOption.Value.GetNumberOperator(),
                gridFilter.Value);

            return query;
        }

        public static string GetNumberOperator(this NumberFilterOption numberFilterOption)
        {
            switch (numberFilterOption)
            {
                case NumberFilterOption.Equals:
                    return NumberFilterConstants.EqualsSqlOperator;

                case NumberFilterOption.DoesNotEqual:
                    return NumberFilterConstants.DoesNotEqualSqlOperator;

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