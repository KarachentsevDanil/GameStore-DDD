using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GSP.Shared.Utils.Data.Extensions
{
    public static class DynamicExtensions
    {
        private const string EntitySelector = "Entity";

        private const string EntityKeySelector = "Entity.Key";

        private const string PropertySeparator = ",";

        private const string GroupByExpressionFormat = "new {{ {0} }}";

        private const string SelectExpressionFormat = "{0} => new {{ {1}, Items = {0} }}";

        public static List<dynamic> GroupByDynamic<TEntity>(this List<TEntity> list, ICollection<string> groupByProperties)
        {
            var groupByField = string.Join(PropertySeparator, groupByProperties.Select(p => $"{p}"));
            var selectGroupedFields = string.Join(PropertySeparator, groupByProperties.Select(p => $"{EntityKeySelector}.{p}"));
            
            var groupByExpression = string.Format(CultureInfo.CurrentCulture, GroupByExpressionFormat, groupByField);
            var selectExpression = string.Format(CultureInfo.CurrentCulture, SelectExpressionFormat, EntitySelector, selectGroupedFields);

            return list.AsQueryable()
                .GroupByDynamic(groupByExpression)
                .SelectDynamic(selectExpression)
                .ToDynamicList();
        }
    }
}