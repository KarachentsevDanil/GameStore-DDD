using GSP.Shared.Grid.Filters.Constants;
using System;

namespace GSP.Shared.Grid.Extensions
{
    public static class StringExtensions
    {
        public static string ToSqlColumn(this string propertyName)
        {
            var column = propertyName.Trim();

            return column.Contains(SqlFilterConstants.Dot, StringComparison.InvariantCultureIgnoreCase) ?
                column :
                $"{SqlFilterConstants.EntityParam}{SqlFilterConstants.Dot}'{column}'";
        }

        public static string ToSqlCondition(this string condition)
        {
            return $"({condition})";
        }
    }
}