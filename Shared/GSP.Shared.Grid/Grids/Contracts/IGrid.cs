using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Searching;
using GSP.Shared.Grid.Sorting;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface IGrid
    {
        SearchModel Search { get; set; }

        PaginationModel Pagination { get; set; }

        ICollection<string> IncludeEntities { get; set; }

        IList<SortingModel> GetSortingOptions();
    }
}