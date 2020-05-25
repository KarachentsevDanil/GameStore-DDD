using GSP.Shared.Grid.Filters;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface ILinqGrid<TEntity> : IGrid<TEntity, LinqFilter<TEntity>>
    {
        Expression<Func<TEntity, bool>> GetGridFiltersLinqExpression();
    }
}