using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Sql.Contracts;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Strategies.Sql
{
    public class DateQueryGeneratorStrategy : ISqlQueryGeneratorStrategy
    {
        public string GetSqlQuery(ISqlFilter gridFilter)
        {
            if (gridFilter.DateFilterOption == DateFilterOption.DateRange)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    DateFilterConstants.DateRangeSqlQuery,
                    gridFilter.PropertyName.ToSqlColumn(),
                    gridFilter.SelectedStartDate,
                    gridFilter.SelectedEndDate);

                return betweenQuery;
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                GetDateSqlQueryTemplate(gridFilter.DateFilterOption.Value),
                gridFilter.PropertyName.ToSqlColumn());

            return query;
        }

        private static string GetDateSqlQueryTemplate(DateFilterOption dateFilterOption)
        {
            return dateFilterOption switch
            {
                DateFilterOption.Blank => DateFilterConstants.BlankDateSqlQuery,

                DateFilterOption.NotBlank => DateFilterConstants.NotBlankDateSqlQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(dateFilterOption), dateFilterOption, null),
            };
        }
    }
}