using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters
{
    public class GridFilter<TEntity> : IGridFilter<TEntity>
    {
        public DateFilterOption? DateFilterOption { get; set; }

        public DateTime? SelectedStartDate { get; set; }

        public DateTime? SelectedEndDate { get; set; }

        public TextFilterOption? TextFilterOption { get; set; }

        public ListFilterOption? ListFilterOption { get; set; }

        public IList<string> Values { get; set; }

        public NumberFilterOption? NumberFilterOption { get; set; }

        public string FirstOperand { get; set; }

        public string SecondOperand { get; set; }

        public BooleanFilterOption? BooleanFilterOption { get; set; }

        public GridFilterType Type { get; set; }

        public string PropertyName { get; set; }

        public string Value { get; set; }

        public bool HasSelectedData =>
            DateFilterOption.HasValue ||
            NumberFilterOption.HasValue ||
            BooleanFilterOption.HasValue ||
            TextFilterOption.HasValue ||
            ListFilterOption.HasValue;

        public Expression<Func<TEntity, bool>> GetFilterExpression()
        {
            switch (Type)
            {
                case GridFilterType.Text:
                    return this.GetTextFilterExpression();

                case GridFilterType.Number:
                    return this.GetNumberFilterExpression();

                case GridFilterType.Date:
                    return this.GetDateFilterExpression();

                case GridFilterType.Boolean:
                    return this.GetBooleanFilterExpression();

                case GridFilterType.List:
                    return this.GetListFilterExpression();
            }

            throw new NotImplementedException($"Filter for type {Type} not implemented");
        }
    }
}