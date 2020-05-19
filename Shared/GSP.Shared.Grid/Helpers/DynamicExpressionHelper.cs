using System;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Helpers
{
    public static class DynamicExpressionHelper
    {
        public static Expression<Func<TType, TReturnValue>> ParseLambda<TType, TReturnValue>(string expression, params object[] values)
        {
            return (Expression<Func<TType, TReturnValue>>)DynamicExpressionParser.ParseLambda(typeof(TType), typeof(TReturnValue), expression, values);
        }
    }
}