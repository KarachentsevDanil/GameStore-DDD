using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Sql.Contracts;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Strategies.Sql
{
    public class TextQueryGeneratorStrategy : ISqlQueryGeneratorStrategy
    {
        public string GetSqlQuery(ISqlFilter gridFilter)
        {
            var queryTemplate = GetTextSqlQueryTemplate(gridFilter.TextFilterOption.Value);

            var query = gridFilter.TextFilterOption == TextFilterOption.Blank || gridFilter.TextFilterOption == TextFilterOption.NotBlank ?
                string.Format(CultureInfo.InvariantCulture, queryTemplate, gridFilter.PropertyName.ToSqlColumn()) :
                string.Format(CultureInfo.InvariantCulture, queryTemplate, gridFilter.PropertyName.ToSqlColumn(), gridFilter.Value);

            return query;
        }

        private static string GetTextSqlQueryTemplate(TextFilterOption textFilterOption)
        {
            return textFilterOption switch
            {
                TextFilterOption.Contains => TextFilterConstants.ContainsSqlQuery,

                TextFilterOption.DoesNotContains => TextFilterConstants.DoesNotContainSqlQuery,

                TextFilterOption.Blank => TextFilterConstants.BlankSqlQuery,

                TextFilterOption.NotBlank => TextFilterConstants.NotBlankSqlQuery,

                TextFilterOption.StartsWith => TextFilterConstants.StartsWithSqlQuery,

                TextFilterOption.EndsWith => TextFilterConstants.EndsWithSqlQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(textFilterOption), textFilterOption, null),
            };
        }
    }
}