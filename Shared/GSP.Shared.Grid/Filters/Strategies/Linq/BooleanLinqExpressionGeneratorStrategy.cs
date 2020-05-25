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
    public class BooleanLinqExpressionGeneratorStrategy<TEntity> : BaseLinqExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(ILinqFilter<TEntity> gridFilter)
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