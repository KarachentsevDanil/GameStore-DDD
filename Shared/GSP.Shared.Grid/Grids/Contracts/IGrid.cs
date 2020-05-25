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
    public interface IGrid<TEntity, TFilterType>
        where TFilterType : IFilter
    {
        ICollection<TFilterType> Filters { get; set; }

        ICollection<SortingModel> SortingOptions { get; set; }

        ICollection<GroupModel> Groups { get; set; }

        ICollection<SummaryModel> Summaries { get; set; }

        ICollection<GroupSummaryModel> GroupSummaries { get; set; }

        SearchModel Search { get; set; }

        PaginationModel Pagination { get; set; }

        ICollection<string> IncludeEntities { get; set; }

        IList<SortingModel> GetSortedSortingOptions();

        ICollection<string> GetGroupNames();
    }
}