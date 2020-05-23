using GSP.Shared.Grid.Builders;
using GSP.Shared.Grid.Columns;
using GSP.Shared.Grid.Filters;
using GSP.Shared.Grid.Grids.Abstract;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Grids.Extensions.Search;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids
{
    public abstract class LinqGrid<TEntity> : BaseGrid<TEntity, LinqGridColumn<TEntity>, LinqFilter<TEntity>>, ILinqGrid<TEntity>
    {
        public Expression<Func<TEntity, bool>> GetGridFiltersLinqExpression()
        {
            var expression = PredicateBuilder.True<TEntity>();

            this.ApplyLinqSearchExpression(expression);

            foreach (var column in Columns.Where(q => q.Filter.HasSelectedData))
            {
                var customFilterExpression = GetCustomColumnExpression(column);
                if (customFilterExpression != null)
                {
                    expression = expression.And(customFilterExpression);
                    continue;
                }

                var filterExpression = column.GetFilterLinqExpression();
                if (filterExpression != null)
                {
                    expression = expression.And(filterExpression);
                }
            }

            return expression;
        }

        protected Expression<Func<TEntity, bool>> GetCustomColumnExpression(LinqGridColumn<TEntity> column)
        {
            return default;
        }
    }
}