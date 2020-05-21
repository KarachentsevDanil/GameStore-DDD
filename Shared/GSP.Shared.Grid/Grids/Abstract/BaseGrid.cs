using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Searching;
using GSP.Shared.Grid.Sorting;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Grids.Abstract
{
    public abstract class BaseGrid : IGrid
    {
        public SearchModel Search { get; set; }

        public PaginationModel Pagination { get; set; }

        public ICollection<string> IncludeEntities { get; set; }

        public abstract IList<SortingModel> GetSortingOptions();
    }
}