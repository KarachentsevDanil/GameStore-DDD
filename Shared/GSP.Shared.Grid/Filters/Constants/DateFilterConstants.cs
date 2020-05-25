﻿namespace GSP.Shared.Grid.Filters.Constants
{
    public static class DateFilterConstants
    {
        public const string DateRangeLinqQuery = "{0} >= @0 And {0} <= @1";

        public const string BlankDateLinqQuery = @"{0} == null";

        public const string NotBlankDateLinqQuery = @"{0} != null";
    }
}