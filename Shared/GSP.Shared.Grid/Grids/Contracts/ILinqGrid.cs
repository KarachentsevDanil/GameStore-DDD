using GSP.Shared.Grid.Columns;
using GSP.Shared.Grid.Filters;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface ILinqGrid<TEntity> : IGrid<TEntity, LinqGridColumn<TEntity>, LinqFilter<TEntity>>
    {
        Expression<Func<TEntity, bool>> GetGridFiltersLinqExpression();
    }
}