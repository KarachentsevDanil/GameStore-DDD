using GSP.Shared.Grid.Expressions.Filters.Constants;
using GSP.Shared.Grid.Expressions.Filters.Strategies.Abstract;
using GSP.Shared.Grid.Helpers;
using GSP.Shared.Grid.Models.Filters;
using GSP.Shared.Grid.Models.Filters.Enums.FilterOptions;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Expressions.Filters.Strategies
{
    public class ListExpressionGeneratorStrategy<TEntity> : BaseExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(Filter gridFilter)
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