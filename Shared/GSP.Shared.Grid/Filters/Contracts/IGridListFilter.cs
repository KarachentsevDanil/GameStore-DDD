using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridListFilter
    {
        ListFilterOption ListFilterOption { get; set; }

        ICollection<string> Values { get; set; }
    }
}