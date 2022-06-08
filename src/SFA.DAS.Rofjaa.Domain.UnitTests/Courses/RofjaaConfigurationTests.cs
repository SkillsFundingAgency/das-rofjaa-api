namespace SFA.DAS.Rofjaa.Domain.Tests.Configuration
{
    using SFA.DAS.Rofjaa.Domain.Configuration;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RofjaaConfigurationTests
    {
        private RofjaaConfiguration _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new RofjaaConfiguration();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new RofjaaConfiguration();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanSetAndGetConnectionString()
        {
            var testValue = "TestValue1713647412";
            _testClass.ConnectionString = testValue;
            Assert.That(_testClass.ConnectionString, Is.EqualTo(testValue));
        }
    }
}