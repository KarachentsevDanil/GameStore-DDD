namespace GSP.Shared.Grid.Filters.Constants
{
    public static class ListFilterConstants
    {
        public const string AnyLinqQuery = @"@0.Contains({0})";

        public const string DoesNotAnyLinqQuery = @"!@0.Contains({0})";

        public const string AnySqlQuery = @"{0} in ({1})";

        public const string DoesNotAnySqlQuery = @"{0} not in ({1})";
    }
}