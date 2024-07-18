using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.AppStart;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Api;

[TestFixture]
public static class ExceptionMiddlewareExtensionsTests
{
    [Test]
    public static void CannotCallConfigureExceptionHandlerWithNullApp()
    {
        Assert.Throws<ArgumentNullException>(() => default(IApplicationBuilder).ConfigureExceptionHandler(Substitute.For<ILogger>()));
    }
}
