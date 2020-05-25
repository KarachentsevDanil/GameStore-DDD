namespace GSP.Shared.Grid.Filters.Constants
{
    public static class NumberFilterConstants
    {
        public const string NumberQuery = "{0} {1} {2}";

        public const string NumberBetweenLinqQuery = "{0} >= @0 And {0} <= @1";

        public const string EqualsLinqOperator = "==";

        public const string DoesNotEqualLinqOperator = "!=";

        public const string GreaterThanOperator = ">";

        public const string GreaterThanOrEqualsOperator = ">=";

        public const string LessThanOperator = "<=";

        public const string LessThanOrEqualsOperator = "<";
    }
}