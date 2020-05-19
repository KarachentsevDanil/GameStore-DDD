using GSP.Shared.Grid.Builders;
using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids
{
    public class Grid<TEntity> : IGrid<TEntity>
    {
        public ICollection<IGridColumn<TEntity>> Columns { get; set; }

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

        public ICollection<SortingModel> GetSortingOptions()
        {
            return Columns.Where(q => q.Direction.HasValue)
                .Select(s => new SortingModel(s.PropertyName, s.Direction.Value))
                .ToList();
        }
    }
}