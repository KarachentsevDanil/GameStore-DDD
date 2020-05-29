using GSP.Shared.Grid.Expressions.Filters.Constants;
using GSP.Shared.Grid.Expressions.Filters.Strategies.Abstract;
using GSP.Shared.Grid.Helpers;
using GSP.Shared.Grid.Models.Filters;
using GSP.Shared.Grid.Models.Filters.Enums.FilterOptions;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Expressions.Filters.Strategies
{
    public class DateExpressionGeneratorStrategy<TEntity> : BaseExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(Filter gridFilter)
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
                GetDateLinqQueryTemplate(gridFilter.DateFilterOption.Value),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        private static string GetDateLinqQueryTemplate(DateFilterOption dateFilterOption)
        {
            return dateFilterOption switch
            {
                DateFilterOption.Blank => DateFilterConstants.BlankDateLinqQuery,

                DateFilterOption.NotBlank => DateFilterConstants.NotBlankDateLinqQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(dateFilterOption), dateFilterOption, null),
            };
        }
    }
}