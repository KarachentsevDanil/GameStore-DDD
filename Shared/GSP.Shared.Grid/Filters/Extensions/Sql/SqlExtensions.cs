using GSP.Shared.Grid.Filters.Constants;
using System;

namespace GSP.Shared.Grid.Filters.Extensions.Sql
{
    public static class SqlExtensions
    {
        public static string ToSqlColumn(this string propertyName)
        {
            var column = propertyName.Trim();

            return column.Contains(SqlFilterConstants.Dot, StringComparison.InvariantCultureIgnoreCase) ?
                column :
                $"{SqlFilterConstants.EntityParam}{SqlFilterConstants.Dot}'{column}'";
        }
    }
}