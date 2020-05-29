using GSP.Shared.Grid.Models.Filters.Enums;
using GSP.Shared.Grid.Models.Filters.Enums.FilterOptions;
using System;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Models.Filters
{
    public class Filter
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