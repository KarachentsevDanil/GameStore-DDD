using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Abstract;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Strategies
{
    public class DateExpressionGeneratorStrategy<TEntity> : BaseExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(IFilter<TEntity> gridFilter)
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