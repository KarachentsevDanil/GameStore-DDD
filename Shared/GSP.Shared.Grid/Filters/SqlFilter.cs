using GSP.Shared.Grid.Filters.Abstract;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Extensions.Sql;
using System;

namespace GSP.Shared.Grid.Filters
{
    public class SqlFilter : BaseFilter, ISqlFilter
    {
        public string GetSqlQuery()
        {
            switch (Type)
            {
                case GridFilterType.Text:
                    return this.GetTextFilterSqlQuery();

                case GridFilterType.Number:
                    return this.GetNumberFilterSqlQuery();

                case GridFilterType.Date:
                    return this.GetDateFilterSqlQuery();

                case GridFilterType.Boolean:
                    return this.GetBooleanFilterSqlQuery();

                case GridFilterType.List:
                    return this.GetListFilterSqlQuery();
            }

            throw new NotImplementedException($"Sql filter expression for type {Type} not implemented");
        }
    }
}