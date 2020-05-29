using System;

namespace GSP.Shared.Grid.Expressions.Filters.Exceptions
{
    public class GridFilterException : Exception
    {
        public GridFilterException(string message)
            : base(message)
        {
        }

        public GridFilterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public GridFilterException()
        {
        }
    }
}