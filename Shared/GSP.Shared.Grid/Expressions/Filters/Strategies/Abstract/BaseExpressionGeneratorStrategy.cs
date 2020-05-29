using GSP.Shared.Grid.Expressions.Filters.Exceptions;
using GSP.Shared.Grid.Expressions.Filters.Strategies.Contracts;
using GSP.Shared.Grid.Models.Filters;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Expressions.Filters.Strategies.Abstract
{
    public abstract class BaseExpressionGeneratorStrategy<TEntity> : IExpressionGeneratorStrategy<TEntity>
    {
        public Expression<Func<TEntity, bool>> GetFilterLinqExpression(Filter gridFilter)
        {
            try
            {
                return GenerateFilterLinqExpression(gridFilter);
            }
            catch (Exception exception)
            {
                var message =
                    $"Error occured while creating expression for {gridFilter.PropertyName}, Filter Type: {gridFilter.Type}, Error: {exception}";

                throw new GridFilterException(message);
            }
        }

        protected abstract Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(Filter gridFilter);
    }
}