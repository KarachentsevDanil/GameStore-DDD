using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GSP.Shared.Utils.Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(
            this Assembly assembly,
            Type openGenericType)
        {
            return assembly.GetTypes()
                .SelectMany(x => x.GetInterfaces(), (type, secondType) => new { type, secondType })
                .Select(many => new { many, baseType = many.type.BaseType })
                .Where(comb =>
                    (comb.baseType != null && comb.baseType.IsGenericType &&
                     openGenericType.IsAssignableFrom(comb.baseType.GetGenericTypeDefinition())) ||
                    (comb.many.secondType.IsGenericType &&
                     openGenericType.IsAssignableFrom(comb.many.secondType.GetGenericTypeDefinition())))
                .Select(r => r.many.type);
        }
    }
}