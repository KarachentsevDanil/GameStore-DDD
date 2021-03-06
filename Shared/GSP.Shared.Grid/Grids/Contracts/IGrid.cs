﻿using GSP.Shared.Grid.Models.Filters;
using GSP.Shared.Grid.Models.Groups;
using GSP.Shared.Grid.Models.Pagination;
using GSP.Shared.Grid.Models.Searching;
using GSP.Shared.Grid.Models.Sorting;
using GSP.Shared.Grid.Models.Summaries;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface IGrid<TEntity>
    {
        List<Filter> Filters { get; set; }

        List<SortingModel> SortingOptions { get; set; }

        List<GroupModel> Groups { get; set; }

        List<SummaryModel> Summaries { get; set; }

        List<GroupSummaryModel> GroupSummaries { get; set; }

        SearchModel Search { get; set; }

        PaginationModel Pagination { get; set; }

        ICollection<string> IncludeEntities { get; set; }

        IList<SortingModel> GetSortedSortingOptions();

        ICollection<string> GetGroupNames();

        ICollection<string> GetIncludedEntities();
    }
}