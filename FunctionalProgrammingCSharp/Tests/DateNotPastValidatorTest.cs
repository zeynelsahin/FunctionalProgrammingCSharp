﻿using FunctionalProgrammingCSharp.Tests.Services;
using FunctionalProgrammingCSharp.Validators;
using NUnit.Framework;

namespace FunctionalProgrammingCSharp.Tests;

public class DateNotPastValidatorTest
{
    private static readonly DateTime PresentDate = new DateTime(2021, 5, 10);
    
    [Test]
    public void WhenTransferDateIsPast_ThenValidationFails()
    {
        var svc = new FakeDateTimeService(PresentDate);
        var sut = new DateNotPastValidator(svc);
        var transfer = MakeTransfer.Dummy with { Date = PresentDate.AddDays(-1) };
        Assert.AreEqual(false,sut.IsValid(transfer));
    }
    //PURE saf
    [Test]
    public void WhenTransferDateIsPastPure_ThenValidationFails()
    {
        var sut = new DateNotPastValidatorPure(new DateTime(2021, 11, 10));
        var transfer = MakeTransfer.Dummy with { Date = PresentDate.AddDays(-1) };
        Assert.AreEqual(false,sut.IsValid(transfer));
    }
    //PURE Func
    [Test]
    public void WhenTransferDateIsPastFunc_ThenValidatorPasses()
    {
        var sut = new DateNotPastValidatorFunc(()=>PresentDate);
        var transfer = MakeTransfer.Dummy with
        {
            Date = PresentDate
        };
        Assert.AreEqual(true,sut.IsValid(transfer));
    }
    
}