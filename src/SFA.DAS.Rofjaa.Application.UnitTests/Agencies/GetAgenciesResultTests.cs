namespace SFA.DAS.Rofjaa.Application.Tests.Agencies.Queries.GetAgencies
{
    using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
    using System;
    using NUnit.Framework;

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