using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Exceptions;
using GSP.Shared.Grid.Filters.Strategies.Linq.Contracts;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Strategies.Linq.Abstract
{
    public abstract class BaseLinqExpressionGeneratorStrategy<TEntity> : ILinqExpressionGeneratorStrategy<TEntity>
    {
        public Expression<Func<TEntity, bool>> GetFilterLinqExpression(ILinqFilter<TEntity> gridFilter)
        {
            try
            {
                return GenerateFilterLinqExpression(gridFilter);
            }
            catch (Exception exception)
            {
                var message =
                    $"Error occured while creating expression for {gridFilter.PropertyName}, Filter Type: {gridFilter.Type}, Error: {exception}";

                throw new GridFilterException(gridFilter, message);
            }
        }

        protected abstract Expression<Func<TEntity, bool>> GenerateFilterLinqExpression(ILinqFilter<TEntity> gridFilter);
    }
}