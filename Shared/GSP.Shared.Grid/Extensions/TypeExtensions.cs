using System;
using TypeSupport.Extensions;

namespace GSP.Shared.Grid.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsBooleanType(this Type type)
        {
            return Type.GetTypeCode(type.ProcessNullableType()) == TypeCode.Boolean;
        }

        public static bool IsDateTimeType(this Type type)
        {
            return Type.GetTypeCode(type.ProcessNullableType()) == TypeCode.DateTime;
        }

        public static bool IsNumericType(this Type type)
        {
            return type.ProcessNullableType().GetExtendedType().IsNumericType;
        }

        public static bool IsStringType(this Type type)
        {
            return type == typeof(string);
        }

        private static Type ProcessNullableType(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
            }

            return type;
        }
    }
}