using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Searching;
using GSP.Shared.Grid.Sorting;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface IGrid<TGridColumn, TFilterType>
        where TFilterType : IFilter
        where TGridColumn : IGridColumn<TFilterType>
    {
        ICollection<TGridColumn> Columns { get; set; }

        SearchModel Search { get; set; }

        PaginationModel Pagination { get; set; }

        ICollection<string> IncludeEntities { get; set; }

        IList<SortingModel> GetSortingOptions();
    }
}