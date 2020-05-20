using GSP.Shared.Grid.Sorting;
using GSP.Shared.Grid.Sorting.Enums;
using GSP.Shared.Utils.Common.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Utils.Data.Extensions
{
    public static class OrderedQueryableExtensions
    {
        private const string EntitySelector = "Entity";

        private const string OrderByMethodName = nameof(Queryable.OrderBy);

        private const string OrderByDescendingMethodName = nameof(Queryable.OrderByDescending);

        private const string ThenByMethodName = nameof(Queryable.ThenBy);

        private const string ThenByDescendingMethodName = nameof(Queryable.ThenByDescending);

        public static IQueryable<TEntity> Ordered<TEntity>(this IQueryable<TEntity> sequence, IList<SortingModel> orderByList)
        {
            if (!orderByList.Any())
            {
                return sequence;
            }

            var expression = CreateOrderByMethodCallExpression(
                sequence, orderByList.First(), sequence.Expression, true);

            for (int i = 1; i < orderByList.Count; i++)
            {
                expression = CreateOrderByMethodCallExpression(
                    sequence, orderByList[i], sequence.Expression, false);
            }

            return sequence.Provider.CreateQuery<TEntity>(expression);
        }

        private static MethodCallExpression CreateOrderByMethodCallExpression<TEntity>(
            IQueryable<TEntity> sequence,
            SortingModel sortingModel,
            Expression expression,
            bool isFirstApply)
        {

            var parameterExpression = Expression.Parameter(typeof(TEntity), EntitySelector);
            var memberExpression = ExpressionHelper.PropertyOrField(parameterExpression, sortingModel.PropertyName);

            var methodName = sortingModel.Direction == SortingDirection.Descending ?
                (isFirstApply ? OrderByDescendingMethodName : ThenByDescendingMethodName) :
                (isFirstApply ? OrderByMethodName : ThenByMethodName);

            return Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { sequence.ElementType, memberExpression.Type },
                expression,
                Expression.Quote(Expression.Lambda(memberExpression, parameterExpression)));
        }
    }
}