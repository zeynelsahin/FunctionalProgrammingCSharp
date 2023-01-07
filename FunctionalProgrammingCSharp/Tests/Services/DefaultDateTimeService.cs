using FunctionalProgrammingCSharp.Tests.Services.Interfaces;

namespace FunctionalProgrammingCSharp.Tests.Services;

public class DefaultDateTimeService: IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}