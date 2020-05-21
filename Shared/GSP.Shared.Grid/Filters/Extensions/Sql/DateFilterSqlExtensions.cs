using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Extensions.Sql
{
    public static class DateFilterSqlExtensions
    {
        public static string GetDateFilterSqlQuery(this ISqlFilter gridFilter)
        {
            if (gridFilter.DateFilterOption == DateFilterOption.DateRange)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    DateFilterConstants.DateRangeSqlQuery,
                    gridFilter.PropertyName,
                    gridFilter.SelectedStartDate,
                    gridFilter.SelectedEndDate);

                return betweenQuery;
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.DateFilterOption.Value.GetDateSqlQuery(),
                gridFilter.PropertyName);

            return query;
        }

        public static string GetDateSqlQuery(this DateFilterOption dateFilterOption)
        {
            switch (dateFilterOption)
            {
                case DateFilterOption.Blank:
                    return DateFilterConstants.BlankDateSqlQuery;

                case DateFilterOption.NotBlank:
                    return DateFilterConstants.NotBlankDateSqlQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(dateFilterOption), dateFilterOption, null);
            }
        }
    }
}