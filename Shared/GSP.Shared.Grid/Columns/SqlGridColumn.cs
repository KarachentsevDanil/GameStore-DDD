using GSP.Shared.Grid.Columns.Abstract;
using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters;
using GSP.Shared.Grid.Filters.Extensions.Sql;

namespace GSP.Shared.Grid.Columns
{
    public class SqlGridColumn : BaseGridColumn, ISqlFilterableColumn
    {
        public SqlFilter Filter { get; set; }

        public string GetFilterSqlQuery()
        {
            Filter.PropertyName = PropertyName.ToSqlColumn();
            return Filter.GetSqlQuery();
        }
    }
}