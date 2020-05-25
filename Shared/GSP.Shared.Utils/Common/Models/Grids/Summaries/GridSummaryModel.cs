using GSP.Shared.Grid.Models.Summaries.Enums;

namespace GSP.Shared.Utils.Common.Models.Grids.Summaries
{
    public class GridSummaryModel
    {
        public GridSummaryModel(string propertyName, SummaryType type, object value)
        {
            PropertyName = propertyName;
            Type = type;
            Value = value;
        }

        public string PropertyName { get; set; }

        public SummaryType Type { get; set; }

        public object Value { get; set; }
    }
}