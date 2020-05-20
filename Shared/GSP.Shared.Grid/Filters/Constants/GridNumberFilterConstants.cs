namespace GSP.Shared.Grid.Filters.Constants
{
    public static class GridNumberFilterConstants
    {
        public const string NumberQuery = "{0} {1} {2}";

        public const string NumberBetweenQuery = "{0} >= @0 And {0} <= @1";

        public const string EqualsOperator = "==";

        public const string DoesNotEqualOperator = "!=";

        public const string GreaterThanOperator = ">";

        public const string GreaterThanOrEqualsOperator = ">=";

        public const string LessThanOperator = "<=";

        public const string LessThanOrEqualsOperator = "<";
    }
}