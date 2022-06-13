namespace SFA.DAS.Rofjaa.Api.UnitTests.AppStart
{
    using SFA.DAS.Rofjaa.Api.AppStart;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using Microsoft.Extensions.DependencyInjection;
    using SFA.DAS.Rofjaa.Domain.Configuration;

    [TestFixture]
    public static class AddDatabaseExtensionTests
    {
        [Test]
        public static void CannotCallAddDatabaseRegistrationWithNullServices()
        {
            Assert.Throws<ArgumentNullException>(() => default(IServiceCollection).AddDatabaseRegistration(new RofjaaConfiguration { ConnectionString = "TestValue83455063" }, "TestValue1873433359"));
        }
    }
}