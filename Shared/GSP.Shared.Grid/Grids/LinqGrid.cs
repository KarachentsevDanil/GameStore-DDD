using GSP.Shared.Grid.Builders;
using GSP.Shared.Grid.Exceptions;
using GSP.Shared.Grid.Filters;
using GSP.Shared.Grid.Grids.Abstract;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Grids.Extensions.Search;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids
{
    public abstract class LinqGrid<TEntity> : BaseGrid<TEntity, LinqFilter<TEntity>>, ILinqGrid<TEntity>
    {
        public Expression<Func<TEntity, bool>> GetGridFiltersLinqExpression()
        {
            var expression = PredicateBuilder.True<TEntity>();

            this.ApplyLinqSearchExpression(expression);

            foreach (var filter in Filters.Where(q => q.HasSelectedData))
            {
                try
                {
                    var customFilterExpression = GetCustomFilterExpression(filter);
                    if (customFilterExpression != null)
                    {
                        expression = expression.And(customFilterExpression);
                        continue;
                    }

                    var filterExpression = filter.GetLinqExpression();
                    if (filterExpression != null)
                    {
                        expression = expression.And(filterExpression);
                    }
                }
                catch (Exception exception)
                {
                    var message =
                        $"Error occured while creating expression for {filter.PropertyName}, Filter Type: {filter.Type}, Error: {exception}";

                    throw new GridFilterException(filter, message);
                }
            }

            return expression;
        }

        protected Expression<Func<TEntity, bool>> GetCustomFilterExpression(LinqFilter<TEntity> filter)
        {
            return default;
        }
    }
}