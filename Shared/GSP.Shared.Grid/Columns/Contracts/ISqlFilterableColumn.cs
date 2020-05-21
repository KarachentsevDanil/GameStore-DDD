using GSP.Shared.Grid.Filters;

namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface ISqlFilterableColumn : IGridColumn
    {
        SqlFilter Filter { get; set; }

        string GetFilterSqlQuery();
    }
}