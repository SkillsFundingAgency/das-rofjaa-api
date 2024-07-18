using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.AppStart;
using SFA.DAS.Rofjaa.Domain.Configuration;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Api;

[TestFixture]
public static class AddDatabaseExtensionTests
{
    [Test]
    public static void CannotCallAddDatabaseRegistrationWithNullServices()
    {
        var action = () => default(IServiceCollection).AddDatabaseRegistration(new RofjaaConfiguration { ConnectionString = "TestValue83455063" }, "TestValue1873433359");
        action.Should().Throw<ArgumentNullException>();
    }
}
