﻿using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Sorting.Enums;

namespace GSP.Shared.Grid.Columns.Abstract
{
    public abstract class BaseGridColumn<TFilterType> : IGridColumn<TFilterType>
        where TFilterType : IFilter
    {
        public SortingDirection? Direction { get; set; }

        public string PropertyName { get; set; }

        public bool IsCalculateTotalNeeded { get; set; }

        public int Order { get; set; }

        public TFilterType Filter { get; set; }
    }
}