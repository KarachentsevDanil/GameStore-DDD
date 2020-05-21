using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions.Linq
{
    public static class BooleanFilterLinqExtensions
    {
        public static Expression<Func<TEntity, bool>> GetBooleanFilterLinqExpression<TEntity>(this ILinqFilter<TEntity> gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                gridFilter.BooleanFilterOption.Value.GetBooleanLinqQuery(),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        public static string GetBooleanLinqQuery(this BooleanFilterOption booleanFilterOption)
        {
            switch (booleanFilterOption)
            {
                case BooleanFilterOption.True:
                    return BooleanFilterConstants.TrueLinqQuery;

                case BooleanFilterOption.False:
                    return BooleanFilterConstants.FalseLinqQuery;

                default:
                    throw new ArgumentOutOfRangeException(nameof(booleanFilterOption), booleanFilterOption, null);
            }
        }
    }
}