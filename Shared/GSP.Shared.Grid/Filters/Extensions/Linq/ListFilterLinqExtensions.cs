using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions.Linq
{
    public static class ListFilterLinqExtensions
    {
        public static Expression<Func<TEntity, bool>> GetListFilterLinqExpression<TEntity>(this ILinqFilter<TEntity> gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.ListFilterOption.Value.GetListLinqQuery(),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query, gridFilter.Values);
        }

        public static string GetListLinqQuery(this ListFilterOption listFilterOption)
        {
            switch (listFilterOption)
            {
                case ListFilterOption.Any:
                    return ListFilterConstants.AnyLinqQuery;

                case ListFilterOption.DoesNotAny:
                    return ListFilterConstants.DoesNotAnyLinqQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(listFilterOption), listFilterOption, null);
            }
        }
    }
}