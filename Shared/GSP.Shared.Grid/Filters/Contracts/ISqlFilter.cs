namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface ISqlFilter : IFilter
    {
        string GetSqlQuery();
    }
}