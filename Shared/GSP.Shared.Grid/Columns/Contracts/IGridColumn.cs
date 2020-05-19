namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface IGridColumn<TEntity> : IFilterableColumn<TEntity>, ISortableColumn
    {
        string PropertyName { get; }
    }
}