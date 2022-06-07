namespace SFA.DAS.Rofjaa.Api.Tests.AppStart
{
    using SFA.DAS.Rofjaa.Api.AppStart;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using Microsoft.AspNetCore.Builder;

    [TestFixture]
    public static class HealthCheckStartupTests
    {

        [Test]
        public static void CannotCallUseHealthChecksWithNullApp()
        {
            Assert.Throws<ArgumentNullException>(() => default(IApplicationBuilder).UseHealthChecks());
        }
    }
}