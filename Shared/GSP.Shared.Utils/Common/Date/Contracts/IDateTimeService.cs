using System;

namespace GSP.Shared.Utils.Common.Date.Contracts
{
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }
    }
}