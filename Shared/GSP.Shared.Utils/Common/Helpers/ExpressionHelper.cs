using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Utils.Common.Helpers
{
    public static class ExpressionHelper
    {
        private const string PropertyDivider = ".";

        public static MemberExpression PropertyOrField(ParameterExpression expression, string nameOfProperty)
        {
            var properties = nameOfProperty.Split(PropertyDivider);

            if (!properties.Any())
            {
                return default;
            }

            MemberExpression memberExpression = Expression.PropertyOrField(expression, properties.First());

            for (int i = 1; i < properties.Length; i++)
            {
                memberExpression = Expression.PropertyOrField(memberExpression, properties[i]);
            }

            return memberExpression;
        }
    }
}