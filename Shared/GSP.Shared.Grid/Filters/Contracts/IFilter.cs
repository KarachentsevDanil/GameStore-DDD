using GSP.Shared.Grid.Filters.Contracts.Types;
using GSP.Shared.Grid.Filters.Enums;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IFilter<TEntity> : ITextFilter, INumberFilter, IBooleanFilter, IDateFilter, IListFilter
    {
        bool HasSelectedData { get; }

        GridFilterType Type { get; set; }

        string PropertyName { get; set; }

        string Value { get; set; }

        Expression<Func<TEntity, bool>> GetExpression();
    }
}