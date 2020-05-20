namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface IGridColumn<TEntity> : IFilterableColumn<TEntity>, ISortableColumn
    {
        string PropertyName { get; set; }

        bool IsCalculateTotalNeeded { get; set; }

        int Order { get; set; }
    }
}