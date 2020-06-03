using GSP.Shared.Grid.Models.Sorting;
using GSP.Shared.Grid.Models.Sorting.Enums;
using GSP.Shared.Grid.Models.Summaries.Enums;
using GSP.Shared.Utils.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

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

        private const string MinMethodName = nameof(Queryable.Min);

        private const string MaxMethodName = nameof(Queryable.Max);

        private const string AverageMethodName = nameof(Queryable.Average);

        private const string CountMethodName = nameof(Queryable.Count);

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

        public static object SummaryDynamic<TEntity>(this IQueryable<TEntity> source, string propertyName, SummaryType summaryType)
        {
            switch (summaryType)
            {
                case SummaryType.Count:
                    {
                        return source.CountDynamic(propertyName);
                    }

                case SummaryType.Sum:
                    {
                        return source.SumDynamic(propertyName);
                    }

                case SummaryType.Min:
                    {
                        return source.MinDynamic(propertyName);
                    }

                case SummaryType.Max:
                    {
                        return source.MaxDynamic(propertyName);
                    }

                case SummaryType.Average:
                    {
                        return source.AverageDynamic(propertyName);
                    }

                default:
                    throw new ArgumentOutOfRangeException(nameof(summaryType), summaryType, "This type of summary haven't implemented yet.");
            }
        }

        public static object SumDynamic<TEntity>(this IQueryable<TEntity> source, string propertyName)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity), EntitySelector);
            var memberExpression = ExpressionHelper.PropertyOrField(parameterExpression, propertyName);
            return source.AggregateQueryDynamic(propertyName, SumMethodName, ((PropertyInfo)memberExpression.Member).PropertyType);
        }

        public static object MinDynamic<TEntity>(this IQueryable<TEntity> source, string propertyName)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity), EntitySelector);
            var memberExpression = ExpressionHelper.PropertyOrField(parameterExpression, propertyName);
            return source.AggregateQueryDynamic(propertyName, MinMethodName, ((PropertyInfo)memberExpression.Member).PropertyType);
        }

        public static object MaxDynamic<TEntity>(this IQueryable<TEntity> source, string propertyName)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity), EntitySelector);
            var memberExpression = ExpressionHelper.PropertyOrField(parameterExpression, propertyName);
            return source.AggregateQueryDynamic(propertyName, MaxMethodName, ((PropertyInfo)memberExpression.Member).PropertyType);
        }

        public static object CountDynamic<TEntity>(this IQueryable<TEntity> source, string propertyName)
        {
            return source.AggregateQueryDynamic(propertyName, CountMethodName, typeof(int));
        }

        public static object AverageDynamic<TEntity>(this IQueryable<TEntity> source, string propertyName)
        {
            return source.AggregateQueryDynamic(propertyName, AverageMethodName, typeof(double));
        }

        public static IQueryable GroupByDynamic(this IQueryable source, string keySelector, params object[] values)
        {
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

        public static IQueryable<TEntity> IncludeMany<TEntity>(this IQueryable<TEntity> query, ICollection<string> includeEntities)
            where TEntity : class
        {
            foreach (var include in includeEntities)
            {
                query = query.Include(include);
            }

            return query;
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

        private static object AggregateQueryDynamic<TEntity>(
            this IQueryable<TEntity> source,
            string propertyName,
            string aggregateMethodName,
            Type returnType)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity), EntitySelector);
            var memberExpression = ExpressionHelper.PropertyOrField(parameterExpression, propertyName);

            var selector = Expression.Lambda(memberExpression, parameterExpression);

            var method = typeof(Queryable).GetMethods().First(
                m => m.Name == aggregateMethodName
                     && m.ReturnType == returnType
                     && m.IsGenericMethod);

            var genericSumMethod = method.MakeGenericMethod(source.ElementType);

            var callExpression = Expression.Call(
                null,
                genericSumMethod,
                new[] { source.Expression, Expression.Quote(selector) });

            return source.Provider.Execute(callExpression);
        }
    }
}