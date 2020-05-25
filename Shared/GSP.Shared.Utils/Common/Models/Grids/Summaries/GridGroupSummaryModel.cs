using GSP.Shared.Grid.Summaries.Enums;

namespace GSP.Shared.Utils.Common.Models.Grids.Summaries
{
    public class GridGroupSummaryModel : GridSummaryModel
    {
        public GridGroupSummaryModel(string propertyName, SummaryType type, object value, string groupName)
            : base(propertyName, type, value)
        {
            GroupName = groupName;
        }

        public string GroupName { get; set; }
    }
}