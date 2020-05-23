using GSP.Shared.Grid.Attributes;

namespace GSP.Shared.Grid.Models
{
    public class GridTypePropertyModel
    {
        public GridTypePropertyModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public bool IsGroupable { get; set; }

        public bool HasTotalCalculationSupport { get; set; }

        public bool IsFilterable { get; set; }

        public void ApplyGridPropertyAttribute(GridPropertyAttribute attribute)
        {
            IsFilterable = attribute.IsFilterable;
            IsGroupable = attribute.IsGroupable;
            Name = attribute.CustomName ?? Name;
            HasTotalCalculationSupport = attribute.HasTotalCalculationSupport;
        }
    }
}