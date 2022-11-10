using System;

namespace SFA.DAS.Rofjaa.Application.Common.DateTime
{
    public interface IDateTimeProvider
    {
        System.DateTime GetNowUtc();
    }
}