using GSP.Shared.Utils.Common.Models.Grids.Summaries;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace GSP.Shared.Utils.Common.Models.Grids
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

        public IImmutableList<dynamic> Items { get; set; }

        public int TotalCount { get; set; }
    }
}