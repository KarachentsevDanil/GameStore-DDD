using System;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Helpers
{
    public static class PredicateHelper
    {
        public static Expression<Func<TType, bool>> True<TType>()
        {
            return f => true;
        }

        public static Expression<Func<TType, bool>> Or<TType>(
            this Expression<Func<TType, bool>> firstExpression,
            Expression<Func<TType, bool>> secondExpression)
        {
            InvocationExpression invokedExpr = Expression.Invoke(secondExpression, firstExpression.Parameters);

            return Expression.Lambda<Func<TType, bool>>(
                Expression.OrElse(firstExpression.Body, invokedExpr), firstExpression.Parameters);
        }

        public static Expression<Func<TType, bool>> And<TType>(
            this Expression<Func<TType, bool>> firstExpression,
            Expression<Func<TType, bool>> secondExpression)
        {
            InvocationExpression invokedExpr = Expression.Invoke(secondExpression, firstExpression.Parameters);

            return Expression.Lambda<Func<TType, bool>>(
                Expression.AndAlso(firstExpression.Body, invokedExpr), firstExpression.Parameters);
        }
    }
}