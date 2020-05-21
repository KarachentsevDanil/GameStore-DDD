using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;

namespace GSP.Shared.Grid.Filters.Contracts.Types
{
    public interface IDateFilter
    {
        DateFilterOption? DateFilterOption { get; set; }

        DateTime? SelectedStartDate { get; set; }

        DateTime? SelectedEndDate { get; set; }
    }
}