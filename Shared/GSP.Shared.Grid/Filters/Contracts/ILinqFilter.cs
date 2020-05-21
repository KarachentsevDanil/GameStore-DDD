using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface ILinqFilter<TEntity> : IFilter
    {
        Expression<Func<TEntity, bool>> GetLinqExpression();
    }
}