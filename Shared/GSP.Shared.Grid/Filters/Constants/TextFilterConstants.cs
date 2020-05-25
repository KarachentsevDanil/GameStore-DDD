namespace GSP.Shared.Grid.Filters.Constants
{
    public static class TextFilterConstants
    {
        public const string ContainsLinqQuery = @"{0}.ToLower().Contains(""{1}"")";

        public const string DoesNotContainLinqQuery = @"!{0}.ToLower().Contains(""{1}"")";

        public const string StartsWithLinqQuery = @"{0}.ToLower().StartsWith(""{1}"")";

        public const string EndsWithLinqQuery = @"{0}.ToLower().EndsWith(""{1}"")";

        public const string BlankLinqQuery = @"string.IsNullOrEmpty({0})";

        public const string NotBlankLinqQuery = @"!string.IsNullOrEmpty({0})";
    }
}