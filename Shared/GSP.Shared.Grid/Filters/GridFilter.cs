using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Extensions;
using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters
{
    public class GridFilter<TEntity> : IGridFilter<TEntity>
    {
        public TextFilterOption TextFilterOption { get; set; }

        public NumberFilterOption NumberFilterOption { get; set; }

        public GridFilterType Type { get; set; }

        public string PropertyName { get; set; }

        public string Value { get; set; }

        public bool HasSelectedData => !string.IsNullOrWhiteSpace(Value);

        public Expression<Func<TEntity, bool>> GetFilterExpression()
        {
            switch (Type)
            {
                case GridFilterType.Text:
                    return this.GetNumberFilterExpression();
                case GridFilterType.Number:
                    return this.GetTextFilterExpression();
                case GridFilterType.Date:
                    break;
                case GridFilterType.Boolean:
                    break;
                case GridFilterType.Enumeration:
                    break;
                case GridFilterType.List:
                    break;
            }

            throw new NotImplementedException($"Filter for type {Type} not implemented");
        }
    }
}