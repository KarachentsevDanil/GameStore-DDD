using GSP.Shared.Grid.Columns;
using GSP.Shared.Grid.Filters;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Extensions.Sql;
using GSP.Shared.Grid.Grids.Abstract;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Grids.Extensions.Search;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Shared.Grid.Grids
{
    public class SqlGrid : BaseGrid<SqlGridColumn, SqlFilter>, ISqlGrid
    {
        public string GetGridFiltersSqlQuery()
        {
            var queries = new List<string>();
            var searchQuery = this.GetSqlSearchQuery();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                queries.Add(searchQuery.ToSqlCondition());
            }

            foreach (var column in Columns.Where(q => q.Filter.HasSelectedData))
            {
                var filterQuery = column.GetFilterSqlQuery();

                if (!string.IsNullOrEmpty(filterQuery))
                {
                    queries.Add(filterQuery.ToSqlCondition());
                }
            }

            return string.Join(SqlFilterConstants.OperatorAndWithSpaces, queries);
        }
    }
}