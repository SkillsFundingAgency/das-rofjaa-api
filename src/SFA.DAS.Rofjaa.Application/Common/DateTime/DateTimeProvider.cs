using System;
using System.Globalization;
using SFA.DAS.Rofjaa.Application.Common.DateTime;

namespace SFA.DAS.Rofjaa.Application.Common.DateTime
{
    public sealed class DateTimeProvider : IDateTimeProvider
    {
        public System.DateTime GetNowUtc()
        {
            return System.DateTime.UtcNow;
        }
    }
}