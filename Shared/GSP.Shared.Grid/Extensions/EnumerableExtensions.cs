using System.Collections.Generic;

namespace GSP.Shared.Grid.Extensions
{
    public static class EnumerableExtensions
    {
        private const string CommaSeparator = ",";

        public static string ToStringList(this IEnumerable<string> collection)
        {
            return string.Join(CommaSeparator, collection);
        }
    }
}