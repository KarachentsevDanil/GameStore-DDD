using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;
using GSP.Shared.Grid.Filters.Strategies;
using GSP.Shared.Grid.Filters.Strategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters
{
    public class Filter<TEntity> : IFilter<TEntity>
    {
        private static readonly IDictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>> LinqExpressionGeneratorStrategies
            = new Dictionary<GridFilterType, IExpressionGeneratorStrategy<TEntity>>();

        static Filter()
        {
            InitializeLinqExpressionGenerator();
        }

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
            return LinqExpressionGeneratorStrategies[Type].GetFilterLinqExpression(this);
        }

        private static void InitializeLinqExpressionGenerator()
        {
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Boolean, new BooleanExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Date, new DateExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.List, new ListExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Number, new NumberExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Text, new TextExpressionGeneratorStrategy<TEntity>());
        }
    }
}