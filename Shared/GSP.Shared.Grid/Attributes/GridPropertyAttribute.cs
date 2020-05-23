using System;

namespace GSP.Shared.Grid.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GridPropertyAttribute : Attribute
    {
        public bool IsGroupable { get; set; }

        public bool HasTotalCalculationSupport { get; set; }

        public string CustomName { get; set; }

        public bool IsFilterable { get; set; }
    }
}