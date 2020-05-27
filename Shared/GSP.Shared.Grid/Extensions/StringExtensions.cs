using System;

namespace GSP.Shared.Grid.Extensions
{
    public static class StringExtensions
    {
        private const string NavigationPropertyDivider = ".";

        public static bool IsNavigationProperty(this string property)
        {
            return property.Contains(NavigationPropertyDivider, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string GetNavigationProperty(this string property)
        {
            return property.Split(NavigationPropertyDivider)[0];
        }
    }
}