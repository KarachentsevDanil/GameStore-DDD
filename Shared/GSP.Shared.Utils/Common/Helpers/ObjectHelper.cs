using System.Reflection;

namespace GSP.Shared.Utils.Common.Helpers
{
    public static class ObjectHelper
    {
        public static object GetPropertyValue(object dynamicObject, string member)
        {
            var value = dynamicObject.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance)?.GetValue(dynamicObject, null);
            return value;
        }
    }
}