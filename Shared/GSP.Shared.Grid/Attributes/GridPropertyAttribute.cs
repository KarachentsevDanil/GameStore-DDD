using System;

namespace GSP.Shared.Grid.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GridPropertyAttribute : Attribute
    {
        public bool IsGroupable { get; set; } = true;

        public bool IsSortable { get; set; } = true;

        public bool IsFilterable { get; set; } = true;

        public bool HasTotalCalculationSupport { get; set; }

        public string CustomName { get; set; }
    }
}