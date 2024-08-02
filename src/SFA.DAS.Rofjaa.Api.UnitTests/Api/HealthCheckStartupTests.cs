using System;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.AppStart;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Api;

[TestFixture]
public static class HealthCheckStartupTests
{
    [Test]
    public static void CannotCallUseHealthChecksWithNullApp() 
    {
        var action = () => default(IApplicationBuilder).UseHealthChecks();
        action.Should().Throw<ArgumentNullException>();
    }
}
