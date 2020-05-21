using GSP.Shared.Grid.Filters;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface ILinqFilterableColumn<TEntity> : IGridColumn
    {
        LinqFilter<TEntity> Filter { get; set; }

        Expression<Func<TEntity, bool>> GetFilterLinqExpression();
    }
}