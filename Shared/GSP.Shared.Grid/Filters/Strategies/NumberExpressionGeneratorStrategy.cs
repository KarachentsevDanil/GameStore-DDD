using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Abstract;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Strategies
{
    public class NumberExpressionGeneratorStrategy<TEntity> : BaseExpressionGeneratorStrategy<TEntity>
    {
        protected override Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(IFilter<TEntity> gridFilter)
        {
            if (gridFilter.NumberFilterOption == NumberFilterOption.Between)
            {
                var betweenQuery = string.Format(
                    CultureInfo.InvariantCulture,
                    NumberFilterConstants.NumberBetweenLinqQuery,
                    gridFilter.PropertyName);

                return DynamicExpressionHelper.ParseLambda<TEntity, bool>(betweenQuery, gridFilter.FirstOperand, gridFilter.SecondOperand);
            }

            var query = string.Format(
                CultureInfo.InvariantCulture,
                NumberFilterConstants.NumberQuery,
                gridFilter.PropertyName,
                GetNumberLinqQueryTemplate(gridFilter.NumberFilterOption.Value),
                gridFilter.Value);

            return DynamicExpressionHelper.ParseLambda<TEntity, bool>(query);
        }

        private static string GetNumberLinqQueryTemplate(NumberFilterOption numberFilterOption)
        {
            return numberFilterOption switch
            {
                NumberFilterOption.Equals => NumberFilterConstants.EqualsLinqOperator,

                NumberFilterOption.DoesNotEqual => NumberFilterConstants.DoesNotEqualLinqOperator,

                NumberFilterOption.GreaterThan => NumberFilterConstants.GreaterThanOperator,

                NumberFilterOption.GreaterThanOrEqual => NumberFilterConstants.GreaterThanOrEqualsOperator,

                NumberFilterOption.LessThan => NumberFilterConstants.LessThanOperator,

                NumberFilterOption.LessThanOrEqual => NumberFilterConstants.LessThanOrEqualsOperator,

                _ => throw new ArgumentOutOfRangeException(nameof(numberFilterOption), numberFilterOption, null),
            };
        }
    }
}