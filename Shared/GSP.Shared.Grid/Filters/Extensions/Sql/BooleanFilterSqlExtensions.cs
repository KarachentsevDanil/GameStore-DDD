using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Extensions.Sql
{
    public static class BooleanFilterSqlExtensions
    {
        public static string GetBooleanFilterSqlQuery(this ISqlFilter gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.BooleanFilterOption.Value.GetBooleanSqlQuery(),
                gridFilter.PropertyName);

            return query;
        }

        public static string GetBooleanSqlQuery(this BooleanFilterOption booleanFilterOption)
        {
            switch (booleanFilterOption)
            {
                case BooleanFilterOption.True:
                    return BooleanFilterConstants.TrueSqlQuery;

                case BooleanFilterOption.False:
                    return BooleanFilterConstants.FalseSqlQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(booleanFilterOption), booleanFilterOption, null);
            }
        }
    }
}