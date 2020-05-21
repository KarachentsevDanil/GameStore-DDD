using GSP.Shared.Grid.Filters;

namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface ISqlFilterableColumn : IGridColumn<SqlFilter>
    {
        string GetFilterSqlQuery();
    }
}