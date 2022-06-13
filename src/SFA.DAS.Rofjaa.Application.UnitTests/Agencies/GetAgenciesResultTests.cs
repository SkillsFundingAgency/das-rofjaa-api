using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using System;
using NUnit.Framework;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgencies
{
    [TestFixture]
    public class GetAgenciesResultTests
    {
        private GetAgenciesResult _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAgenciesResult();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgenciesResult();
            Assert.That(instance, Is.Not.Null);
        }
    }
}