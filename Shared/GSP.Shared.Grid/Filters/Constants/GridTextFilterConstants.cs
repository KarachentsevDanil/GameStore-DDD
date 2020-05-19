namespace GSP.Shared.Grid.Filters.Constants
{
    public static class GridTextFilterConstants
    {
        public const string ContainsQuery = @"{0}.ToLower().Contains(""{1}"")";

        public const string DoesNotContainQuery = @"!{0}.ToLower().Contains(""{1}"")";
    }
}