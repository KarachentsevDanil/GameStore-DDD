using GSP.Shared.Grid.Builders;
using GSP.Shared.Grid.Columns;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids
{
    public class BaseGrid<TEntity> : IGrid<TEntity>
    {
        public ICollection<GridColumn<TEntity>> Columns { get; set; }

        public PaginationModel Pagination { get; set; }

        public Expression<Func<TEntity, bool>> GetGridFilterExpression()
        {
            var expression = PredicateBuilder.True<TEntity>();

            foreach (var column in Columns.Where(q => q.Filter.HasSelectedData))
            {
                var filterExpression = column.GetFilterExpression();

                if (filterExpression != null)
                {
                    expression = expression.And(filterExpression);
                }
            }

            return expression;
        }

        public IList<SortingModel> GetSortingOptions()
        {
            return Columns
                .Where(q => q.Direction.HasValue)
                .OrderBy(o => o.Order)
                .Select(s => new SortingModel(s.PropertyName, s.Direction.Value))
                .ToList();
        }
    }
}