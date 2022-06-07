namespace SFA.DAS.Rofjaa.Api.Tests.Infrastructure
{
    using SFA.DAS.Rofjaa.Api.Infrastructure;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public static class RoleNamesTests
    {
        [Test]
        public static void CanGetDefault()
        {
            Assert.That(RoleNames.Default, Is.InstanceOf<string>());
            Assert.Fail("Create or modify test");
        }

        [Test]
        public static void CanGetDataLoad()
        {
            Assert.That(RoleNames.DataLoad, Is.InstanceOf<string>());
            Assert.Fail("Create or modify test");
        }
    }
}