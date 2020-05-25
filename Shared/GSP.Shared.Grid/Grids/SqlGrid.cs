using GSP.Shared.Grid.Extensions;
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
    public abstract class SqlGrid<TEntity> : BaseGrid<TEntity, SqlFilter>, ISqlGrid<TEntity>
    {
        public string GetGridFiltersSqlQuery()
        {
            var queries = new List<string>();
            var searchQuery = this.GetSqlSearchQuery();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                queries.Add(searchQuery.ToSqlCondition());
            }

            foreach (var filter in Filters.Where(q => q.HasSelectedData))
            {
                var customQueryProcessor = GetCustomFilterQuery(filter);
                if (!string.IsNullOrEmpty(customQueryProcessor))
                {
                    queries.Add(customQueryProcessor.ToSqlCondition());
                    continue;
                }

                var filterQuery = filter.GetSqlQuery();
                if (!string.IsNullOrEmpty(filterQuery))
                {
                    queries.Add(filterQuery.ToSqlCondition());
                }
            }

            return string.Join(SqlFilterConstants.OperatorAndWithSpaces, queries);
        }

        protected virtual string GetCustomFilterQuery(SqlFilter filter)
        {
            return null;
        }
    }
}