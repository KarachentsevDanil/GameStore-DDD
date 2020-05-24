using GSP.Shared.Grid.Attributes;
using System;

namespace GSP.Shared.Grid.Models
{
    public class GridTypePropertyModel
    {
        public GridTypePropertyModel(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }

        public bool IsGroupable { get; set; } = true;

        public bool IsFilterable { get; set; } = true;

        public bool IsSortable { get; set; } = true;

        public bool HasTotalCalculationSupport { get; set; }

        public Type Type { get; set; }

        public void ApplyGridPropertyAttribute(GridPropertyAttribute attribute)
        {
            IsFilterable = attribute.IsFilterable;
            IsGroupable = attribute.IsGroupable;
            IsSortable = attribute.IsSortable;
            Name = attribute.CustomName ?? Name;
            HasTotalCalculationSupport = attribute.HasTotalCalculationSupport;
        }
    }
}