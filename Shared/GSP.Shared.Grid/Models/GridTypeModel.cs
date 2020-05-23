using System;
using System.Collections.Generic;

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
    }
}