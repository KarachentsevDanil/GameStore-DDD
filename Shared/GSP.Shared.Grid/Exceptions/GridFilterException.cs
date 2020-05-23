using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using System;

namespace GSP.Shared.Grid.Exceptions
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

        public GridFilterType FilterType { get; set; }

        public string PropertyName { get; set; }

        public IFilter Filter { get; set; }
    }
}