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

        public const string ContainsSqlQuery = @"{0} like N'%{1}%'";

        public const string DoesNotContainSqlQuery = @"{0} not like N'%{1}%'";

        public const string StartsWithSqlQuery = @"{0} like N'{1}%'";

        public const string EndsWithSqlQuery = @"{0} like N'%{1}'";

        public const string BlankSqlQuery = @"{0} is null or {0} = ''";

        public const string NotBlankSqlQuery = @"{0} is not null and {0} <> ''";
    }
}