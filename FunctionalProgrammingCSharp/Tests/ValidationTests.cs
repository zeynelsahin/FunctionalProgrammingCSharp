using FunctionalProgrammingCSharp.Tests.Services;
using FunctionalProgrammingCSharp.Validators;
using NUnit.Framework;

namespace FunctionalProgrammingCSharp.Tests;

public class ValidationTests
{
    [Test]
    public void WhenTransferDateIsFuture()
    {
        var sut = new DateNotPastValidator(new DefaultDateTimeService());
        var transfer = MakeTransfer.Dummy with { Date = new DateTime(2021, 3, 12) };
        var actual = sut.IsValid(transfer);
        Assert.AreEqual(true, actual);
    }
}