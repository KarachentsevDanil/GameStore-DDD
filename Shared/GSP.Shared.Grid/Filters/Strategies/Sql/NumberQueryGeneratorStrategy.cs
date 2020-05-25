using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Sql.Contracts;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Strategies.Sql
{
    public class NumberQueryGeneratorStrategy : ISqlQueryGeneratorStrategy
    {
        public string GetSqlQuery(ISqlFilter gridFilter)
        {
            if (gridFilter.NumberFilterOption == NumberFilterOption.Between)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    NumberFilterConstants.NumberBetweenSqlQuery,
                    gridFilter.PropertyName.ToSqlColumn(),
                    gridFilter.FirstOperand,
                    gridFilter.SecondOperand);

                return betweenQuery;
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                NumberFilterConstants.NumberQuery,
                gridFilter.PropertyName.ToSqlColumn(),
                GetNumberSqlQueryTemplate(gridFilter.NumberFilterOption.Value),
                gridFilter.Value);

            return query;
        }

        private static string GetNumberSqlQueryTemplate(NumberFilterOption numberFilterOption)
        {
            return numberFilterOption switch
            {
                NumberFilterOption.Equals => NumberFilterConstants.EqualsSqlOperator,

                NumberFilterOption.DoesNotEqual => NumberFilterConstants.DoesNotEqualSqlOperator,

                NumberFilterOption.GreaterThan => NumberFilterConstants.GreaterThanOperator,

                NumberFilterOption.GreaterThanOrEqual => NumberFilterConstants.GreaterThanOrEqualsOperator,

                NumberFilterOption.LessThan => NumberFilterConstants.LessThanOperator,

                NumberFilterOption.LessThanOrEqual => NumberFilterConstants.LessThanOrEqualsOperator,

                _ => throw new ArgumentOutOfRangeException(nameof(numberFilterOption), numberFilterOption, null),
            };
        }
    }
}