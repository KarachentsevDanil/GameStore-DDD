using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;
using System.Globalization;
using System.Linq;

namespace GSP.Shared.Grid.Filters.Extensions.Sql
{
    public static class ListFilterSqlExtensions
    {
        public static string GetListFilterSqlQuery(this ISqlFilter gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.ListFilterOption.Value.GetListSqlQuery(),
                gridFilter.PropertyName,
                string.Join(SqlFilterConstants.Comma, gridFilter.Values.Select(v => $"'{gridFilter.Values}'")));

            return query;
        }

        public static string GetListSqlQuery(this ListFilterOption listFilterOption)
        {
            switch (listFilterOption)
            {
                case ListFilterOption.Any:
                    return ListFilterConstants.AnySqlQuery;

                case ListFilterOption.DoesNotAny:
                    return ListFilterConstants.DoesNotAnySqlQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(listFilterOption), listFilterOption, null);
            }
        }
    }
}