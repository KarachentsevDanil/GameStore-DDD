namespace GSP.Shared.Utils.Common.Models.Grids
{
    public class GridGroupColumnModel
    {
        public GridGroupColumnModel(string group, string propertyName, object total)
        {
            Group = group;
            PropertyName = propertyName;
            Total = total;
        }

        public string Group { get; set; }

        public string PropertyName { get; set; }

        public object Total { get; set; }
    }
}