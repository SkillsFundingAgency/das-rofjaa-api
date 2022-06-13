using SFA.DAS.Rofjaa.Application.Models;
using NUnit.Framework;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Models
{
    [TestFixture]
    public class AgencyTests
    {
        private Agency _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Agency();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new Agency();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanSetAndGetLegalEntityId()
        {
            var testValue = 43691550;
            _testClass.LegalEntityId = testValue;
            Assert.That(_testClass.LegalEntityId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetIsGrantFunded()
        {
            var testValue = false;
            _testClass.IsGrantFunded = testValue;
            Assert.That(_testClass.IsGrantFunded, Is.EqualTo(testValue));
        }
    }
}