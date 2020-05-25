using GSP.Shared.Grid.Filters.Abstract;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Strategies.Sql;
using GSP.Shared.Grid.Filters.Strategies.Sql.Contracts;
using System.Collections.Generic;

namespace GSP.Shared.Grid.Filters
{
    public class SqlFilter : BaseFilter, ISqlFilter
    {
        private static readonly IDictionary<GridFilterType, ISqlQueryGeneratorStrategy> SqlQueryGeneratorStrategies
            = new Dictionary<GridFilterType, ISqlQueryGeneratorStrategy>();

        static SqlFilter()
        {
            InitializeSqlExpressionGenerator();
        }

        public string GetSqlQuery()
        {
            return SqlQueryGeneratorStrategies[Type].GetSqlQuery(this);
        }

        private static void InitializeSqlExpressionGenerator()
        {
            SqlQueryGeneratorStrategies.Add(GridFilterType.Boolean, new BooleanQueryGeneratorStrategy());
            SqlQueryGeneratorStrategies.Add(GridFilterType.Date, new DateQueryGeneratorStrategy());
            SqlQueryGeneratorStrategies.Add(GridFilterType.List, new ListQueryGeneratorStrategy());
            SqlQueryGeneratorStrategies.Add(GridFilterType.Number, new NumberQueryGeneratorStrategy());
            SqlQueryGeneratorStrategies.Add(GridFilterType.Text, new TextQueryGeneratorStrategy());
        }
    }
}