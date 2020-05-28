using GSP.Shared.Grid.Grids;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Expressions.Contracts
{
    public interface IGridExpressionGenerator<TEntity>
    {
        Expression<Func<TEntity, bool>> GetGridExpression(BaseGrid<TEntity> grid);
    }
}