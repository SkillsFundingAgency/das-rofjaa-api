using System;
using System.Globalization;
using SFA.DAS.Rofjaa.Application.Common.DateTime;

namespace SFA.DAS.Rofjaa.Application.Common.DateTime
{
    public sealed class DateTimeProvider : IDateTimeProvider
    {
        private static readonly IFormatProvider culture = new CultureInfo("en-GB", true);

        public System.DateTime GetNowUtc()
        {
            return System.DateTime.UtcNow;
        }

        public System.DateTime ConvertUtcToUk(System.DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
        }

        public System.DateTime ConvertOpaToLocalDateTime(string opaDateTime)
        {
            return Convert.ToDateTime(opaDateTime, culture);
        }
    }
}