namespace GSP.Shared.Utils.Common.Models.Grids
{
    public class GridColumnModel
    {
        public GridColumnModel(string propertyName, object total)
        {
            PropertyName = propertyName;
            Total = total;
        }

        public string PropertyName { get; set; }

        public object Total { get; set; }
    }
}