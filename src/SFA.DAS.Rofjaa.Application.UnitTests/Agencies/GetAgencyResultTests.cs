using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using System;
using NUnit.Framework;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgency
{
    [TestFixture]
    public class GetAgencyResultTests
    {
        private GetAgencyResult _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAgencyResult();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgencyResult();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanSetAndGetLegalEntityId()
        {
            var testValue = 505870637;
            _testClass.LegalEntityId = testValue;
            Assert.That(_testClass.LegalEntityId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetIsGrantFunded()
        {
            var testValue = true;
            _testClass.IsGrantFunded = testValue;
            Assert.That(_testClass.IsGrantFunded, Is.EqualTo(testValue));
        }
    }
}