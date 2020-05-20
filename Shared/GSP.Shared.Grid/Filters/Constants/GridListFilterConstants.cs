namespace GSP.Shared.Grid.Filters.Constants
{
    public static class GridListFilterConstants
    {
        public const string AnyQuery = @"@0.Any(item => item == {0})";

        public const string DoesNotAnyQuery = @"!@0.Any(item => item == {0})";
    }
}