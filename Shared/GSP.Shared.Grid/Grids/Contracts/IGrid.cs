using GSP.Shared.Grid.Columns;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Sorting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface IGrid<TEntity>
    {
        ICollection<GridColumn<TEntity>> Columns { get; set; }

        PaginationModel Pagination { get; set; }

        Expression<Func<TEntity, bool>> GetGridFilterExpression();

        IList<SortingModel> GetSortingOptions();
    }
}