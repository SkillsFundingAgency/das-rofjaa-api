using System;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.AppStart;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Api;

[TestFixture]
public static class ExceptionMiddlewareExtensionsTests
{
    [Test]
    public static void CannotCallConfigureExceptionHandlerWithNullApp()
    {
        var action = () => default(IApplicationBuilder).ConfigureExceptionHandler(Mock.Of<ILogger>());
        action.Should().Throw<ArgumentNullException>();
    }
}
