using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridTextFilter
    {
        TextFilterOption? TextFilterOption { get; set; }
    }
}