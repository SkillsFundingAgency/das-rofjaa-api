namespace SFA.DAS.Rofjaa.Api.Tests.AppStart
{
    using SFA.DAS.Rofjaa.Api.AppStart;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using Microsoft.Extensions.DependencyInjection;

    [TestFixture]
    public static class AddServiceRegistrationExtensionTests
    {

        [Test]
        public static void CannotCallAddServiceRegistrationWithNullServices()
        {
            Assert.Throws<ArgumentNullException>(() => default(IServiceCollection).AddServiceRegistration());
        }
    }
}