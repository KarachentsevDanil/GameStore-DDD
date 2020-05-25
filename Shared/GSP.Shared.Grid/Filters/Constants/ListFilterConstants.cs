namespace GSP.Shared.Grid.Filters.Constants
{
    public static class ListFilterConstants
    {
        public const string AnyLinqQuery = @"@0.Contains({0})";

        public const string DoesNotAnyLinqQuery = @"!@0.Contains({0})";
    }
}