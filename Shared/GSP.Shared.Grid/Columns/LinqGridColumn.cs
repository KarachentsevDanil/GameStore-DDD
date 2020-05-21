using GSP.Shared.Grid.Columns.Abstract;
using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Columns
{
    public class LinqGridColumn<TEntity> : BaseGridColumn<LinqFilter<TEntity>>, ILinqFilterableColumn<TEntity>
    {
        public Expression<Func<TEntity, bool>> GetFilterLinqExpression()
        {
            Filter.PropertyName = PropertyName;
            return Filter.GetLinqExpression();
        }
    }
}