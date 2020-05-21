using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Extensions.Sql
{
    public static class TextFilterSqlExtensions
    {
        public static string GetTextFilterSqlQuery(this ISqlFilter gridFilter)
        {
            var textFilterOption = gridFilter.TextFilterOption.Value;

            var query = gridFilter.TextFilterOption == TextFilterOption.Blank || gridFilter.TextFilterOption == TextFilterOption.NotBlank ?
                string.Format(CultureInfo.InvariantCulture, textFilterOption.GetTextSqlQuery(), gridFilter.PropertyName) :
                string.Format(CultureInfo.InvariantCulture, textFilterOption.GetTextSqlQuery(), gridFilter.PropertyName, gridFilter.Value);

            return query;
        }

        public static string GetTextSqlQuery(this TextFilterOption textFilterOption)
        {
            switch (textFilterOption)
            {
                case TextFilterOption.Contains:
                    return TextFilterConstants.ContainsSqlQuery;

                case TextFilterOption.DoesNotContains:
                    return TextFilterConstants.DoesNotContainSqlQuery;

                case TextFilterOption.Blank:
                    return TextFilterConstants.BlankSqlQuery;

                case TextFilterOption.NotBlank:
                    return TextFilterConstants.NotBlankSqlQuery;

                case TextFilterOption.StartsWith:
                    return TextFilterConstants.StartsWithSqlQuery;

                case TextFilterOption.EndsWith:
                    return TextFilterConstants.EndsWithSqlQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(textFilterOption), textFilterOption, null);
            }
        }
    }
}