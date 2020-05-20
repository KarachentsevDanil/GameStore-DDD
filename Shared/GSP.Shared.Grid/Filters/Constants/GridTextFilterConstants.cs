namespace GSP.Shared.Grid.Filters.Constants
{
    public static class GridTextFilterConstants
    {
        public const string ContainsQuery = @"{0}.ToLower().Contains(""{1}"")";

        public const string DoesNotContainQuery = @"!{0}.ToLower().Contains(""{1}"")";

        public const string StartsWithQuery = @"{0}.ToLower().StartsWith(""{1}"")";

        public const string EndsWithQuery = @"{0}.ToLower().EndsWith(""{1}"")";

        public const string BlankQuery = @"string.IsNullOrEmpty({0})";

        public const string NotBlankQuery = @"!string.IsNullOrEmpty({0})";
    }
}