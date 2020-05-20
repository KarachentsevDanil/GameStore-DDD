using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions
{
    public static class ListFilterExtensions
    {
        public static Expression<Func<TEntity, bool>> GetListFilterExpression<TEntity>(this IGridFilter<TEntity> gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.ListFilterOption.GetListQuery(),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query, gridFilter.Values);
        }

        public static string GetListQuery(this ListFilterOption listFilterOption)
        {
            switch (listFilterOption)
            {
                case ListFilterOption.Any:
                    return GridListFilterConstants.AnyQuery;
                case ListFilterOption.DoesNotAny:
                    return GridListFilterConstants.DoesNotAnyQuery;
                default:
                    throw new ArgumentOutOfRangeException(nameof(listFilterOption), listFilterOption, null);
            }
        }
    }
}