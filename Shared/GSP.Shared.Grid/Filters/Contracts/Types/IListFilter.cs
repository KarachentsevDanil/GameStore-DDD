using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Filters.Contracts.Types
{
    public interface IListFilter
    {
        ListFilterOption? ListFilterOption { get; set; }

        IList<string> Values { get; set; }
    }
}