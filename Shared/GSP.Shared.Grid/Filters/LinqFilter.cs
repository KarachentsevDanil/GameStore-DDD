using GSP.Shared.Grid.Filters.Abstract;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Extensions.Linq;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters
{
    public class LinqFilter<TEntity> : BaseFilter, ILinqFilter<TEntity>
    {
        public Expression<Func<TEntity, bool>> GetLinqExpression()
        {
            switch (Type)
            {
                case GridFilterType.Text:
                    return this.GetTextFilterLinqExpression();

                case GridFilterType.Number:
                    return this.GetNumberFilterLinqExpression();

                case GridFilterType.Date:
                    return this.GetDateFilterLinqExpression();

                case GridFilterType.Boolean:
                    return this.GetBooleanFilterLinqExpression();

                case GridFilterType.List:
                    return this.GetListFilterLinqExpression();
            }

            throw new NotImplementedException($"Linq filter expression for type {Type} not implemented");
        }
    }
}