using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies.Stores;
using GSP.Shared.Grid.Filters.Strategies.Stores.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters
{
    public class Filter<TEntity> : IFilter<TEntity>
    {
        private static readonly IFilterExpressionGeneratorStore<TEntity> FilterExpressionGeneratorStore
            = new FilterExpressionGeneratorStore<TEntity>();

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

        public virtual bool HasSelectedData =>
            DateFilterOption.HasValue ||
            NumberFilterOption.HasValue ||
            BooleanFilterOption.HasValue ||
            TextFilterOption.HasValue ||
            ListFilterOption.HasValue;

        public Expression<Func<TEntity, bool>> GetExpression()
        {
            return FilterExpressionGeneratorStore.FilterExpressionGeneratorStrategies[Type].GetFilterLinqExpression(this);
        }
    }
}