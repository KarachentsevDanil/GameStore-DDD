using GSP.Shared.Grid.Sorting.Enums;

namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface ISortableColumn
    {
        SortingDirection? Direction { get; set; }
    }
}