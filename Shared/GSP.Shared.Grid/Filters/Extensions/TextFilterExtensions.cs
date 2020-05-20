using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions
{
    public static class TextFilterExtensions
    {
        public static Expression<Func<TEntity, bool>> GetTextFilterExpression<TEntity>(this IGridFilter<TEntity> gridFilter)
        {
            var textFilterOption = gridFilter.TextFilterOption.Value;

            var query = gridFilter.TextFilterOption == TextFilterOption.Blank || gridFilter.TextFilterOption == TextFilterOption.NotBlank ?
                string.Format(CultureInfo.InvariantCulture, textFilterOption.GetTextQuery(), gridFilter.PropertyName) :
                string.Format(CultureInfo.InvariantCulture, textFilterOption.GetTextQuery(), gridFilter.PropertyName, gridFilter.Value);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetTextQuery(this TextFilterOption textFilterOption)
        {
            switch (textFilterOption)
            {
                case TextFilterOption.Contains:
                    return GridTextFilterConstants.ContainsQuery;
                case TextFilterOption.DoesNotContains:
                    return GridTextFilterConstants.DoesNotContainQuery;
                case TextFilterOption.Blank:
                    return GridTextFilterConstants.BlankQuery;
                case TextFilterOption.NotBlank:
                    return GridTextFilterConstants.NotBlankQuery;
                case TextFilterOption.StartsWith:
                    return GridTextFilterConstants.StartsWithQuery;
                case TextFilterOption.EndsWith:
                    return GridTextFilterConstants.EndsWithQuery;
                default:
                    throw new ArgumentOutOfRangeException(nameof(textFilterOption), textFilterOption, null);
            }
        }
    }
}