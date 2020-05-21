using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts.Types
{
    public interface ITextFilter
    {
        TextFilterOption? TextFilterOption { get; set; }
    }
}