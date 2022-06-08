using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using System;
using NUnit.Framework;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgencies
{
    [TestFixture]
    public class GetAgenciesQueryTests
    {
        private GetAgenciesQuery _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GetAgenciesQuery();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgenciesQuery();
            Assert.That(instance, Is.Not.Null);
        }
    }
}