namespace SFA.DAS.Rofjaa.Api.Tests.ApiResponses
{
    using SFA.DAS.Rofjaa.Api.ApiResponses;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GetAgencyResponseTests
    {
        private GetAgencyResponse _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAgencyResponse();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgencyResponse();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanSetAndGetLegalEntityId()
        {
            var testValue = 1806481352;
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