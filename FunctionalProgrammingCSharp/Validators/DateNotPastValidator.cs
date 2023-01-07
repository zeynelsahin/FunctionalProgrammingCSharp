using System.Diagnostics.Contracts;
using FunctionalProgrammingCSharp.Tests.Services.Interfaces;

namespace FunctionalProgrammingCSharp.Validators;

public record DateNotPastValidator (IDateTimeService DateTimeService): IValidator<MakeTransfer>
{
 
    private IDateTimeService DateService { get; } = DateTimeService;
    public bool IsValid(MakeTransfer transfer) => (DateService.UtcNow.Date <= transfer.Date.Date);
}

public record DateNotPastValidatorPure (DateTime Today): IValidator<MakeTransfer>
{
    public bool IsValid(MakeTransfer transfer) => (Today <= transfer.Date.Date);
}

public record DateNotPastValidatorFunc(Func<DateTime> Clock) : IValidator<MakeTransfer>
{
    public bool IsValid(MakeTransfer transfer) => Clock().Date <= transfer.Date.Date;
};
