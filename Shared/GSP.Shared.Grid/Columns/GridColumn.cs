using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters;
using GSP.Shared.Grid.Sorting.Enums;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Columns
{
    public class GridColumn<TEntity> : IGridColumn<TEntity>
    {
        public GridFilter<TEntity> Filter { get; set; }

        public SortingDirection? Direction { get; set; }

        public string PropertyName { get; set; }

        public bool IsCalculateTotalNeeded { get; set; }

        public int Order { get; set; }

        public Expression<Func<TEntity, bool>> GetFilterExpression()
        {
            Filter.PropertyName = PropertyName;

            return Filter.GetFilterExpression();
        }
    }
}