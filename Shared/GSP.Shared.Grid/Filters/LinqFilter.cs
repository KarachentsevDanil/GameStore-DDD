using GSP.Shared.Grid.Filters.Abstract;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Filters.Strategies.Linq;
using GSP.Shared.Grid.Filters.Strategies.Linq.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Filters
{
    public class LinqFilter<TEntity> : BaseFilter, ILinqFilter<TEntity>
    {
        private static readonly IDictionary<GridFilterType, ILinqExpressionGeneratorStrategy<TEntity>> LinqExpressionGeneratorStrategies
            = new Dictionary<GridFilterType, ILinqExpressionGeneratorStrategy<TEntity>>();

        static LinqFilter()
        {
            InitializeLinqExpressionGenerator();
        }

        public Expression<Func<TEntity, bool>> GetLinqExpression()
        {
            return LinqExpressionGeneratorStrategies[Type].GetFilterLinqExpression(this);
        }

        private static void InitializeLinqExpressionGenerator()
        {
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Boolean, new BooleanLinqExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Date, new DateLinqExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.List, new ListLinqExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Number, new NumberLinqExpressionGeneratorStrategy<TEntity>());
            LinqExpressionGeneratorStrategies.Add(GridFilterType.Text, new TextLinqExpressionGeneratorStrategy<TEntity>());
        }
    }
}