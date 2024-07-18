namespace SFA.DAS.Rofjaa.Application.Common.DateTime;

public interface IDateTimeProvider
{
    System.DateTime GetNowUtc();
}

public sealed class DateTimeProvider : IDateTimeProvider
{
    public System.DateTime GetNowUtc()
    {
        return System.DateTime.UtcNow;
    }
}
