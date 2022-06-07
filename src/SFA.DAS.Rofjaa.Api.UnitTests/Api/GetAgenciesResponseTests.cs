namespace SFA.DAS.Rofjaa.Api.Tests.ApiResponses
{
    using SFA.DAS.Rofjaa.Api.ApiResponses;
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class GetAgenciesResponseTests
    {
        private GetAgenciesResponse _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAgenciesResponse();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgenciesResponse();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanSetAndGetAgencies()
        {
            var testValue = new[] { new GetAgenciesResponse.Agency { LegalEntityId = 1423772741, IsGrantFunded = true }, new GetAgenciesResponse.Agency { LegalEntityId = 1436015291, IsGrantFunded = true }, new GetAgenciesResponse.Agency { LegalEntityId = 1706355305, IsGrantFunded = false } };
            _testClass.Agencies = testValue;
            Assert.That(_testClass.Agencies, Is.EqualTo(testValue));
        }
    }
}