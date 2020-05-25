using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Sql.Contracts;
using System;
using System.Globalization;

namespace GSP.Shared.Grid.Filters.Strategies.Sql
{
    public class BooleanQueryGeneratorStrategy : ISqlQueryGeneratorStrategy
    {
        public string GetSqlQuery(ISqlFilter gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                GetBooleanSqlQueryTemplate(gridFilter.BooleanFilterOption.Value),
                gridFilter.PropertyName.ToSqlColumn());

            return query;
        }

        private static string GetBooleanSqlQueryTemplate(BooleanFilterOption booleanFilterOption)
        {
            return booleanFilterOption switch
            {
                BooleanFilterOption.True => BooleanFilterConstants.TrueSqlQuery,

                BooleanFilterOption.False => BooleanFilterConstants.FalseSqlQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(booleanFilterOption), booleanFilterOption, null),
            };
        }
    }
}