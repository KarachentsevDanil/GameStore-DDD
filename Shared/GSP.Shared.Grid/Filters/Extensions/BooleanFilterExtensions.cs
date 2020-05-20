using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions
{
    public static class BooleanFilterExtensions
    {
        public static Expression<Func<TEntity, bool>> GetBooleanFilterExpression<TEntity>(this IGridFilter<TEntity> gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.BooleanFilterOption.Value.GetBooleanQuery(),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetBooleanQuery(this BooleanFilterOption booleanFilterOption)
        {
            switch (booleanFilterOption)
            {
                case BooleanFilterOption.True:
                    return GridBooleanFilterConstants.TrueQuery;
                case BooleanFilterOption.False:
                    return GridBooleanFilterConstants.FalseQuery;
                default:
                    throw new ArgumentOutOfRangeException(nameof(booleanFilterOption), booleanFilterOption, null);
            }
        }
    }
}