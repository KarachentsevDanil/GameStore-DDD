using GSP.Shared.Grid.Filters;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface ISqlGrid<TEntity> : IGrid<TEntity, SqlFilter>
    {
        string GetGridFiltersSqlQuery();
    }
}