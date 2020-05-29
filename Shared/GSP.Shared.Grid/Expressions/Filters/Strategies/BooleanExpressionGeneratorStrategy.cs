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
    public class BooleanExpressionGeneratorStrategy<TEntity> : BaseExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(Filter gridFilter)
        {
            var query = string.Format(
                CultureInfo.InvariantCulture,
                GetBooleanLinqQueryTemplate(gridFilter.BooleanFilterOption.Value),
                gridFilter.PropertyName);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        private static string GetBooleanLinqQueryTemplate(BooleanFilterOption booleanFilterOption)
        {
            return booleanFilterOption switch
            {
                BooleanFilterOption.True => BooleanFilterConstants.TrueLinqQuery,

                BooleanFilterOption.False => BooleanFilterConstants.FalseLinqQuery,

                _ => throw new ArgumentOutOfRangeException(nameof(booleanFilterOption), booleanFilterOption, null)
            };
        }
    }
}