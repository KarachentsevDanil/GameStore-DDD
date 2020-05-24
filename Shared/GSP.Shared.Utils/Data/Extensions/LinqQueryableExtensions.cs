using GSP.Shared.Grid.Sorting;
using GSP.Shared.Grid.Sorting.Enums;
using GSP.Shared.Utils.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.Extensions
{
    public static class LinqQueryableExtensions
    {
        private const string EntitySelector = "Entity";

        private const string OrderByMethodName = nameof(Queryable.OrderBy);

        private const string OrderByDescendingMethodName = nameof(Queryable.OrderByDescending);

        private const string ThenByMethodName = nameof(Queryable.ThenBy);

        private const string ThenByDescendingMethodName = nameof(Queryable.ThenByDescending);

        private const string GroupByMethodName = nameof(Queryable.GroupBy);

        private const string SumMethodName = nameof(Queryable.Sum);

        private const string DynamicElementSelector = "it";

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

        public static object SumDynamic<TEntity>(this IQueryable<TEntity> source, string propertyName)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity), EntitySelector);
            var memberExpression = ExpressionHelper.PropertyOrField(parameterExpression, propertyName);

            var selector = Expression.Lambda(memberExpression, parameterExpression);

            var sumMethod = typeof(Queryable).GetMethods().First(
                m => m.Name == SumMethodName
                     && m.ReturnType == ((PropertyInfo)memberExpression.Member).PropertyType
                     && m.IsGenericMethod);

            var genericSumMethod = sumMethod.MakeGenericMethod(source.ElementType);

            var callExpression = Expression.Call(
                null,
                genericSumMethod,
                new[] { source.Expression, Expression.Quote(selector) });

            return source.Provider.Execute(callExpression);
        }

        public static IQueryable GroupByDynamic(this IQueryable source, string keySelector, params object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            LambdaExpression keyLambda = DynamicExpressionParser.ParseLambda(source.ElementType, null, keySelector, values);
            LambdaExpression elementLambda = DynamicExpressionParser.ParseLambda(source.ElementType, null, DynamicElementSelector, values);

            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    GroupByMethodName,
                    new[] { source.ElementType, keyLambda.Body.Type, elementLambda.Body.Type },
                    source.Expression,
                    Expression.Quote(keyLambda),
                    Expression.Quote(elementLambda)));
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