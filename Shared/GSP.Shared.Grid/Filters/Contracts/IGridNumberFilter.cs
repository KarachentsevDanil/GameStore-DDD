using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridNumberFilter<TEntity>
    {
        NumberFilterOption NumberFilterOption { get; set; }
    }
}