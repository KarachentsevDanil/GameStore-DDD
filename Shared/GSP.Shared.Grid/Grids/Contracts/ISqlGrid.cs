using GSP.Shared.Grid.Columns;
using GSP.Shared.Grid.Filters;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface ISqlGrid : IGrid<SqlGridColumn, SqlFilter>
    {
        string GetGridFiltersSqlQuery();
    }
}