using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions.Linq
{
    public static class DateFilterLinqExtensions
    {
        public static Expression<Func<TEntity, bool>> GetDateFilterLinqExpression<TEntity>(this ILinqFilter<TEntity> gridFilter)
        {
            if (gridFilter.DateFilterOption == DateFilterOption.DateRange)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    DateFilterConstants.DateRangeLinqQuery,
                    gridFilter.PropertyName);

                return DynamicExpressionHelper.ParseLambda<TEntity, bool>(betweenQuery, gridFilter.SelectedStartDate, gridFilter.SelectedEndDate);
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.DateFilterOption.Value.GetDateLinqQuery(),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetDateLinqQuery(this DateFilterOption dateFilterOption)
        {
            switch (dateFilterOption)
            {
                case DateFilterOption.Blank:
                    return DateFilterConstants.BlankDateLinqQuery;

                case DateFilterOption.NotBlank:
                    return DateFilterConstants.NotBlankDateLinqQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(dateFilterOption), dateFilterOption, null);
            }
        }
    }
}