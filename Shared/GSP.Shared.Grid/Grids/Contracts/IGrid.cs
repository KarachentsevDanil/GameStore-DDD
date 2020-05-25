using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Models.Groups;
using GSP.Shared.Grid.Models.Pagination;
using GSP.Shared.Grid.Models.Searching;
using GSP.Shared.Grid.Models.Sorting;
using GSP.Shared.Grid.Models.Summaries;
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