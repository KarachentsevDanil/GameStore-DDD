using GSP.Shared.Grid.Columns;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface ISqlGrid : IGrid
    {
        ICollection<SqlGridColumn> Columns { get; set; }

        string GetGridFiltersSqlQuery();
    }
}