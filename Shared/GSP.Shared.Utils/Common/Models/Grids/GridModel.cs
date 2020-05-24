using GSP.Shared.Utils.Common.Models.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace GSP.Shared.Utils.Common.Models.Grids
{
    public class GridModel
    {
        public GridModel(ICollection<GridColumnModel> columnsWithTotal, IImmutableList<dynamic> items, int totalCount)
        {
            ColumnsWithTotal = columnsWithTotal;
            Items = items;
            TotalCount = totalCount;
        }

        public GridModel(ICollection<GridGroupColumnModel> groupedColumnsWithTotal, IImmutableList<dynamic> items, int totalCount)
        {
            GroupedColumnsWithTotal = groupedColumnsWithTotal;
            Items = items;
            TotalCount = totalCount;
        }

        public ICollection<GridColumnModel> ColumnsWithTotal { get; set; }

        public ICollection<GridGroupColumnModel> GroupedColumnsWithTotal { get; set; }

        public IImmutableList<dynamic> Items { get; set; }

        public int TotalCount { get; set; }
    }
}