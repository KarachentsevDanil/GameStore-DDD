using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Exceptions;
using GSP.Shared.Grid.Filters.Strategies.Contracts;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Strategies.Abstract
{
    public abstract class BaseExpressionGeneratorStrategy<TEntity> : IExpressionGeneratorStrategy<TEntity>
    {
        public Expression<Func<TEntity, bool>> GetFilterLinqExpression(IFilter<TEntity> gridFilter)
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

        protected abstract Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(IFilter<TEntity> gridFilter);
    }
}