using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using System;
using NUnit.Framework;
using Moq;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgency
{
    [TestFixture]
    public class GetAgencyQueryTests
    {
        private GetAgencyQuery _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAgencyQuery();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgencyQuery();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanSetAndGetLegalEntityId()
        {
            var testValue = 612008439;
            _testClass.LegalEntityId = testValue;
            Assert.That(_testClass.LegalEntityId, Is.EqualTo(testValue));
        }


    }
}