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
    public class TextExpressionGeneratorStrategy<TEntity> : BaseExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(IFilter<TEntity> gridFilter)
        {
            var textLinqQuery = GetTextLinqQueryTemplate(gridFilter.TextFilterOption.Value);

            var query = gridFilter.TextFilterOption == TextFilterOption.Blank || gridFilter.TextFilterOption == TextFilterOption.NotBlank ?
                string.Format(CultureInfo.InvariantCulture, textLinqQuery, gridFilter.PropertyName) :
                string.Format(CultureInfo.InvariantCulture, textLinqQuery, gridFilter.PropertyName, gridFilter.Value);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        private static string GetTextLinqQueryTemplate(TextFilterOption textFilterOption)
        {
            return textFilterOption switch
            {
                TextFilterOption.Contains => TextFilterConstants.ContainsLinqQuery,

                TextFilterOption.DoesNotContains => TextFilterConstants.DoesNotContainLinqQuery,

                TextFilterOption.Blank => TextFilterConstants.BlankLinqQuery,

                TextFilterOption.NotBlank => TextFilterConstants.NotBlankLinqQuery,

                TextFilterOption.StartsWith => TextFilterConstants.StartsWithLinqQuery,

                TextFilterOption.EndsWith => TextFilterConstants.EndsWithLinqQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(textFilterOption), textFilterOption, null)
            };
        }
    }
}