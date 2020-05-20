using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions
{
    public static class DateFilterExtensions
    {
        public static Expression<Func<TEntity, bool>> GetDateFilterExpression<TEntity>(this IGridFilter<TEntity> gridFilter)
        {
            if (gridFilter.DateFilterOption == DateFilterOption.DateRange)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    GridDateFilterConstants.DateRangeQuery,
                    gridFilter.PropertyName);

                return DynamicExpressionHelper.ParseLambda<TEntity, bool>(betweenQuery, gridFilter.SelectedStartDate, gridFilter.SelectedEndDate);
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.DateFilterOption.Value.GetDateQuery(),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetDateQuery(this DateFilterOption dateFilterOption)
        {
            switch (dateFilterOption)
            {
                case DateFilterOption.Blank:
                    return GridDateFilterConstants.BlankDateQuery;

                case DateFilterOption.NotBlank:
                    return GridDateFilterConstants.NotBlankDateQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(dateFilterOption), dateFilterOption, null);
            }
        }
    }
}