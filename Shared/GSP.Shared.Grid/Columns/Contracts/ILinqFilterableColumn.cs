using GSP.Shared.Grid.Filters;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Columns.Contracts
{
    public interface ILinqFilterableColumn<TEntity> : IGridColumn<LinqFilter<TEntity>>
    {
        Expression<Func<TEntity, bool>> GetFilterLinqExpression();
    }
}