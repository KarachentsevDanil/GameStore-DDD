using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Extensions.Sql;
using GSP.Shared.Grid.Grids.Contracts;
using System.Globalization;

namespace GSP.Shared.Grid.Grids.Extensions.Search
{
    public static class SqlSearchExtensions
    {
        public static string GetSqlSearchQuery<TEntity>(this ISqlGrid<TEntity> grid)
        {
            if (string.IsNullOrEmpty(grid.Search?.Term))
            {
                return string.Empty;
            }

            var searchQuery = string.Empty;

            foreach (var property in grid.Search.SearchFields)
            {
                var query = string.Format(
                    CultureInfo.InvariantCulture, TextFilterConstants.ContainsSqlQuery, property, grid.Search.Term);

                searchQuery = string.Join(SqlFilterConstants.OperatorOrWithSpaces, query.ToSqlCondition(), searchQuery);
            }

            return searchQuery;
        }
    }
}