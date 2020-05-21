using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions.Linq
{
    public static class TextFilterLinqExtensions
    {
        public static Expression<Func<TEntity, bool>> GetTextFilterLinqExpression<TEntity>(this ILinqFilter<TEntity> gridFilter)
        {
            var textFilterOption = gridFilter.TextFilterOption.Value;

            var query = gridFilter.TextFilterOption == TextFilterOption.Blank || gridFilter.TextFilterOption == TextFilterOption.NotBlank ?
                string.Format(CultureInfo.InvariantCulture, textFilterOption.GetTextLinqQuery(), gridFilter.PropertyName) :
                string.Format(CultureInfo.InvariantCulture, textFilterOption.GetTextLinqQuery(), gridFilter.PropertyName, gridFilter.Value);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetTextLinqQuery(this TextFilterOption textFilterOption)
        {
            switch (textFilterOption)
            {
                case TextFilterOption.Contains:
                    return TextFilterConstants.ContainsLinqQuery;

                case TextFilterOption.DoesNotContains:
                    return TextFilterConstants.DoesNotContainLinqQuery;

                case TextFilterOption.Blank:
                    return TextFilterConstants.BlankLinqQuery;

                case TextFilterOption.NotBlank:
                    return TextFilterConstants.NotBlankLinqQuery;

                case TextFilterOption.StartsWith:
                    return TextFilterConstants.StartsWithLinqQuery;

                case TextFilterOption.EndsWith:
                    return TextFilterConstants.EndsWithLinqQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(textFilterOption), textFilterOption, null);
            }
        }
    }
}