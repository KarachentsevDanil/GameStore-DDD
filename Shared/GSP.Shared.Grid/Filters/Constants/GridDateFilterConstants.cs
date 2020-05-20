namespace GSP.Shared.Grid.Filters.Constants
{
    public static class GridDateFilterConstants
    {
        public const string DateRangeQuery = "{0} >= @0 And {0} <= @1";

        public const string BlankDateQuery = @"{0} == null";

        public const string NotBlankDateQuery = @"{0} != null";
    }
}