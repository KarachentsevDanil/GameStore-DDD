﻿using GSP.Shared.Grid.Builders;
using GSP.Shared.Grid.Filters.Constants;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Helpers;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids.Extensions.Search
{
    public static class LinqSearchExtensions
    {
        public static void ApplyLinqSearchExpression<TEntity>(this ILinqGrid<TEntity> grid, Expression<Func<TEntity, bool>> gridExpression)
        {
            if (string.IsNullOrEmpty(grid.Search?.Term))
            {
                return;
            }

            var expression = PredicateBuilder.True<TEntity>();

            foreach (var property in grid.Search.SearchFields)
            {
                var query = string.Format(CultureInfo.InvariantCulture, TextFilterConstants.ContainsLinqQuery, property, grid.Search.Term);
                expression = expression.Or(DynamicExpressionHelper.ParseLambda<TEntity, bool>(query));
            }

            gridExpression = gridExpression.And(expression);
        }
    }
}