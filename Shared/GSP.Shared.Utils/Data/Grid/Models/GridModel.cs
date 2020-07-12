using GSP.Shared.Utils.Data.Grid.Models.Summaries;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace GSP.Shared.Utils.Data.Grid.Models
{
    public class GridModel
    {
        public GridModel(ICollection<GridSummaryModel> summaries, IImmutableList<dynamic> items, int totalCount)
        {
            Summaries = summaries;
            Items = items;
            TotalCount = totalCount;
        }

        public GridModel(ICollection<GridSummaryModel> summaries, ICollection<GridGroupSummaryModel> groupSummaries, IImmutableList<dynamic> items, int totalCount)
        {
            Summaries = summaries;
            GroupSummaries = groupSummaries;
            Items = items;
            TotalCount = totalCount;
        }

        public ICollection<GridSummaryModel> Summaries { get; }

        public ICollection<GridGroupSummaryModel> GroupSummaries { get; }

        public IImmutableList<dynamic> Items { get; }

        public int TotalCount { get; set; }
    }
}