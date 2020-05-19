using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridTextFilter<TEntity>
    {
        TextFilterOption TextFilterOption { get; set; }
    }
}