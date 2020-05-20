using GSP.Shared.Utils.Common.Models.Collections;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.Models.Grids
{
    public class GridModel<TEntity>
        where TEntity : class
    {
        public GridModel(ICollection<GridColumnModel> columnsWithTotal, PagedCollection<TEntity> pagedCollection)
        {
            ColumnsWithTotal = columnsWithTotal;
            PagedCollection = pagedCollection;
        }

        public ICollection<GridColumnModel> ColumnsWithTotal { get; set; }

        public PagedCollection<TEntity> PagedCollection { get; set; }
    }
}