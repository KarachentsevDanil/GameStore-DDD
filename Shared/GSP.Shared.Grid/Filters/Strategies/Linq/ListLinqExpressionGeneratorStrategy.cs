using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Linq.Abstract;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Strategies.Linq
{
    public class ListLinqExpressionGeneratorStrategy<TEntity> : BaseLinqExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(ILinqFilter<TEntity> gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                GetListLinqQueryTemplate(gridFilter.ListFilterOption.Value),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query, gridFilter.Values);
        }

        private static string GetListLinqQueryTemplate(ListFilterOption listFilterOption)
        {
            return listFilterOption switch
            {
                ListFilterOption.Any => ListFilterConstants.AnyLinqQuery,

                ListFilterOption.DoesNotAny => ListFilterConstants.DoesNotAnyLinqQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(listFilterOption), listFilterOption, null)
            };
        }
    }
}