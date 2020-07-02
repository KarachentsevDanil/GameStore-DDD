using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Utils.Common.Models.Grids;
using GSP.Shared.Utils.Common.Models.Grids.Summaries;
using GSP.Shared.Utils.Domain.Base;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static GSP.Shared.Utils.Data.Extensions.DynamicExtensions;

namespace GSP.Shared.Utils.Data.Extensions
{
    public static class GridExtensions
    {
        public static ICollection<GridSummaryModel> GetGridSummaries<TEntity>(
            this IGrid<TEntity> grid, IQueryable<TEntity> query)
            where TEntity : BaseEntity
        {
            var summaries = new List<GridSummaryModel>();

            foreach (var summary in grid.Summaries)
            {
                object value = query.SummaryDynamic(summary.PropertyName, summary.Type);
                var summaryModel = new GridSummaryModel(summary.PropertyName, summary.Type, value);
                summaries.Add(summaryModel);
            }

            return summaries;
        }

        public static GridModel GetGroupedGridItems<TEntity>(
            this IGrid<TEntity> grid,
            List<TEntity> dbItems,
            ICollection<GridSummaryModel> gridSummaries,
            int totalCount)
            where TEntity : BaseEntity
        {
            var gridGroups = grid.GetGroupNames();

            var groupedItems = dbItems.GroupByDynamic(gridGroups);

            return new GridModel(
                gridSummaries, GetGridGroupSummaries(grid, groupedItems, gridGroups), groupedItems.ToImmutableList(), totalCount);
        }

        public static ICollection<GridGroupSummaryModel> GetGridGroupSummaries<TEntity>(
            this IGrid<TEntity> grid, List<dynamic> list, ICollection<string> groupedProperties)
            where TEntity : BaseEntity
        {
            var summaries = new List<GridGroupSummaryModel>();

            foreach (var groupSummary in grid.GroupSummaries)
            {
                foreach (var group in list)
                {
                    ICollection<TEntity> groupedItems = GetCollection<TEntity>(group);
                    string groupKey = GetGroupKey(group, groupedProperties);

                    object value = groupedItems.AsQueryable().SummaryDynamic(groupSummary.PropertyName, groupSummary.Type);
                    var summaryModel = new GridGroupSummaryModel(groupSummary.PropertyName, groupSummary.Type, value, groupKey);
                    summaries.Add(summaryModel);
                }
            }

            return summaries;
        }
    }
}