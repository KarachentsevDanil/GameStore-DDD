using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Searching;
using GSP.Shared.Grid.Sorting;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Shared.Grid.Grids.Abstract
{
    public abstract class BaseGrid<TGridColumn, TFilterType> : IGrid<TGridColumn, TFilterType>
        where TFilterType : IFilter
        where TGridColumn : IGridColumn<TFilterType>
    {
        public ICollection<TGridColumn> Columns { get; set; }

        public SearchModel Search { get; set; }

        public PaginationModel Pagination { get; set; }

        public ICollection<string> IncludeEntities { get; set; }

        public virtual IList<SortingModel> GetSortingOptions()
        {
            return Columns
                .Where(q => q.Direction.HasValue)
                .OrderBy(o => o.Order)
                .Select(s => new SortingModel(s.PropertyName, s.Direction.Value))
                .ToList();
        }
    }
}