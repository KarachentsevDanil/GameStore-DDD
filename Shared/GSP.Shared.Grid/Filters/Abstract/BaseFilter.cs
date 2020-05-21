using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Filters.Abstract
{
    public abstract class BaseFilter : IFilter
    {
        public DateFilterOption? DateFilterOption { get; set; }

        public DateTime? SelectedStartDate { get; set; }

        public DateTime? SelectedEndDate { get; set; }

        public TextFilterOption? TextFilterOption { get; set; }

        public ListFilterOption? ListFilterOption { get; set; }

        public IList<string> Values { get; set; }

        public NumberFilterOption? NumberFilterOption { get; set; }

        public string FirstOperand { get; set; }

        public string SecondOperand { get; set; }

        public BooleanFilterOption? BooleanFilterOption { get; set; }

        public GridFilterType Type { get; set; }

        public string PropertyName { get; set; }

        public string Value { get; set; }

        public virtual bool HasSelectedData =>
            DateFilterOption.HasValue ||
            NumberFilterOption.HasValue ||
            BooleanFilterOption.HasValue ||
            TextFilterOption.HasValue ||
            ListFilterOption.HasValue;
    }
}