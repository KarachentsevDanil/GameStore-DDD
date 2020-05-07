using GSP.Shared.Utils.Common.Date.Contracts;
using System;

namespace GSP.Shared.Utils.Common.Date
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow { get; } = DateTime.UtcNow;
    }
}