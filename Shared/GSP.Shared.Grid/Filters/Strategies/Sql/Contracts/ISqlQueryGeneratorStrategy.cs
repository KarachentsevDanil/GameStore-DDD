using GSP.Shared.Grid.Filters.Contracts;

namespace GSP.Shared.Grid.Filters.Strategies.Sql.Contracts
{
    public interface ISqlQueryGeneratorStrategy
    {
        string GetSqlQuery(ISqlFilter gridFilter);
    }
}