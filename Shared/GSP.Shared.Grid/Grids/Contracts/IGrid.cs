using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Groups;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Searching;
using GSP.Shared.Grid.Sorting;
using GSP.Shared.Grid.Summaries;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface IGrid<TEntity, TGridColumn, TFilterType>
        where TFilterType : IFilter
        where TGridColumn : IGridColumn<TFilterType>
    {
        ICollection<TGridColumn> Columns { get; set; }

        ICollection<GroupModel> Groups { get; set; }

        ICollection<SummaryModel> Summaries { get; set; }

        ICollection<GroupSummaryModel> GroupSummaries { get; set; }

        SearchModel Search { get; set; }

        PaginationModel Pagination { get; set; }

        ICollection<string> IncludeEntities { get; set; }

        IList<SortingModel> GetSortingOptions();

        ICollection<string> GetGroupNames();
    }
}