using System;

namespace SFA.DAS.Rofjaa.Application.Common.DateTime
{
    public interface IDateTimeProvider
    {
        System.DateTime GetNowUtc();

        System.DateTime ConvertUtcToUk(System.DateTime utcDateTime);

        System.DateTime ConvertOpaToLocalDateTime(string opaDateTime);
    }
}