using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Sql.Contracts;
using System;
using System.Globalization;
using System.Linq;

namespace GSP.Shared.Grid.Filters.Strategies.Sql
{
    public class ListQueryGeneratorStrategy : ISqlQueryGeneratorStrategy
    {
        public string GetSqlQuery(ISqlFilter gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                GetListSqlQueryTemplate(gridFilter.ListFilterOption.Value),
                gridFilter.PropertyName.ToSqlColumn(),
                string.Join(SqlFilterConstants.Comma, gridFilter.Values.Select(v => $"'{gridFilter.Values}'")));

            return query;
        }

        private static string GetListSqlQueryTemplate(ListFilterOption listFilterOption)
        {
            return listFilterOption switch
            {
                ListFilterOption.Any => ListFilterConstants.AnySqlQuery,

                ListFilterOption.DoesNotAny => ListFilterConstants.DoesNotAnySqlQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(listFilterOption), listFilterOption, null),
            };
        }
    }
}