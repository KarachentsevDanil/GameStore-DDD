using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Extensions
{
    public static class TextFilterExtensions
    {
        public static Expression<Func<TEntity, bool>> GetTextFilterExpression<TEntity>(this IGridFilter<TEntity> gridFilter)
        {
            var query = string.Empty;

            switch (gridFilter.TextFilterOption)
            {
                case TextFilterOption.Contains:
                    {
                        query = string.Format(
                            CultureInfo.InvariantCulture,
                            GridTextFilterConstants.ContainsQuery,
                            gridFilter.PropertyName,
                            gridFilter.Value);
                        break;
                    }

                case TextFilterOption.DoesNotContains:
                    {
                        query = string.Format(
                            CultureInfo.InvariantCulture,
                            GridTextFilterConstants.DoesNotContainQuery,
                            gridFilter.PropertyName,
                            gridFilter.Value);
                        break;
                    }
            }

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }
    }
}