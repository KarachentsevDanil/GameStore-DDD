using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridBooleanFilter
    {
        BooleanFilterOption? BooleanFilterOption { get; set; }
    }
}