using GSP.Shared.Grid.Columns;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface ILinqGrid<TEntity> : IGrid
    {
        ICollection<LinqGridColumn<TEntity>> Columns { get; set; }

        Expression<Func<TEntity, bool>> GetGridFiltersLinqExpression();
    }
}