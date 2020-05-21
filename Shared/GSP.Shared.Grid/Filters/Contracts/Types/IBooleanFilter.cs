using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts.Types
{
    public interface IBooleanFilter
    {
        BooleanFilterOption? BooleanFilterOption { get; set; }
    }
}