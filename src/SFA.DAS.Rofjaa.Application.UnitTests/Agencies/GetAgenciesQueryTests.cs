namespace SFA.DAS.Rofjaa.Application.Tests.Agencies.Queries.GetAgencies
{
    using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
    using System;
    using NUnit.Framework;

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