using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridDateFilter
    {
        DateFilterOption DateFilterOption { get; set; }

        DateTime? SelectedStartDate { get; set; }

        DateTime? SelectedEndDate { get; set; }
    }
}