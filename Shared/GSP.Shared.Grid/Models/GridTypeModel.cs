using GSP.Shared.Grid.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Shared.Grid.Models
{
    public class GridTypeModel
    {
        public GridTypeModel(Type gridType, ICollection<GridTypePropertyModel> properties, ICollection<string> includedEntities)
        {
            GridType = gridType;
            Properties = properties;
            IncludedEntities = includedEntities;
        }

        public Type GridType { get; set; }

        public ICollection<GridTypePropertyModel> Properties { get; set; }

        public ICollection<string> IncludedEntities { get; set; }

        public ICollection<string> GroupablePropertyNames => Properties.Where(p => p.IsGroupable).Select(p => p.Name).ToList();

        public ICollection<string> FilterablePropertyNames => Properties.Where(p => p.IsFilterable).Select(p => p.Name).ToList();

        public ICollection<string> SortablePropertyNames => Properties.Where(p => p.IsSortable).Select(p => p.Name).ToList();

        public ICollection<string> CalculablePropertyNames => Properties.Where(p => p.HasTotalCalculationSupport).Select(p => p.Name).ToList();

        public ICollection<string> PropertyNames => Properties.Select(p => p.Name).ToList();

        public ICollection<string> BooleanProperties => Properties.Where(p => p.Type.IsBooleanType()).Select(p => p.Name).ToList();

        public ICollection<string> DateTimeProperties => Properties.Where(p => p.Type.IsDateTimeType()).Select(p => p.Name).ToList();

        public ICollection<string> NumericProperties => Properties.Where(p => p.Type.IsNumericType()).Select(p => p.Name).ToList();

        public ICollection<string> TextProperties => Properties.Where(p => p.Type.IsStringType()).Select(p => p.Name).ToList();
    }
}