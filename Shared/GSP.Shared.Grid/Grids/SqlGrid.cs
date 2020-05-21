﻿using GSP.Shared.Grid.Columns;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Grids.Abstract;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Sorting;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Shared.Grid.Grids
{
    public class SqlGrid : BaseGrid, ISqlGrid
    {
        public ICollection<SqlGridColumn> Columns { get; set; }

        public string GetGridFiltersSqlQuery()
        {
            var queries = new List<string>();

            foreach (var column in Columns.Where(q => q.Filter.HasSelectedData))
            {
                var filterQuery = column.GetFilterSqlQuery();

                if (!string.IsNullOrEmpty(filterQuery))
                {
                    queries.Add($"({filterQuery})");
                }
            }

            return string.Join(SqlFilterConstants.OperatorAndWithSpaces, queries);
        }

        public override IList<SortingModel> GetSortingOptions()
        {
            return Columns
                .Where(q => q.Direction.HasValue)
                .OrderBy(o => o.Order)
                .Select(s => new SortingModel(s.PropertyName, s.Direction.Value))
                .ToList();
        }
    }
}