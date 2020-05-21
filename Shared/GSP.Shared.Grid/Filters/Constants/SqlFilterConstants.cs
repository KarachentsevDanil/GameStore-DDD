namespace GSP.Shared.Grid.Filters.Constants
{
    public static class SqlFilterConstants
    {
        public const string EntityParam = "Entity";

        public const string Dot = ".";

        public const string Comma = ",";

        public const string OperatorAnd = "AND";

        public const string OperatorOr = "OR";

        public static string OperatorAndWithSpaces => $" {OperatorAnd} ";

        public static string OperatorOrWithSpaces => $" {OperatorOr} ";
    }
}