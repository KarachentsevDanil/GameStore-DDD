using GSP.Shared.Grid.Filters.Enums;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters.Contracts
{
    public interface IGridFilter<TEntity> : IGridTextFilter, IGridNumberFilter, IGridBooleanFilter, IGridDateFilter, IGridListFilter
    {
        bool HasSelectedData { get; }

        GridFilterType Type { get; set; }

        string PropertyName { get; set; }

        string Value { get; set; }

        Expression<Func<TEntity, bool>> GetFilterExpression();
    }
}