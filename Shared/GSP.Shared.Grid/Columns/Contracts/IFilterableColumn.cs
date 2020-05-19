using GSP.Shared.Grid.Filters.Contracts;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface IFilterableColumn<TEntity>
    {
        IGridFilter<TEntity> Filter { get; set; }

        Expression<Func<TEntity, bool>> GetFilterExpression();
    }
}