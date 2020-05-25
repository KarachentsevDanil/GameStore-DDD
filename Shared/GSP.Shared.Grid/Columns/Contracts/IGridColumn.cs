using GSP.Shared.Grid.Filters.Contracts;

namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface IGridColumn<TFilterType> : ISortableColumn
        where TFilterType : IFilter
    {
        string PropertyName { get; set; }

        int Order { get; set; }

        TFilterType Filter { get; set; }
    }
}