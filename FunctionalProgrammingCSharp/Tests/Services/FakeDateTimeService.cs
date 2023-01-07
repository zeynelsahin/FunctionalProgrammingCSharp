using FunctionalProgrammingCSharp.Tests.Services.Interfaces;

namespace FunctionalProgrammingCSharp.Tests.Services;

public class FakeDateTimeService: IDateTimeService
{
    public DateTime UtcNow { get; } = default;

    public FakeDateTimeService(DateTime presentDate)
    {
        UtcNow = presentDate;
    }
}