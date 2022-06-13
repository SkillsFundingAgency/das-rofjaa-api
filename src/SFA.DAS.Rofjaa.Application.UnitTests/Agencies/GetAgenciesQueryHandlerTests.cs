using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using System;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgencies
{
    [TestFixture]
    public class GetAgenciesQueryHandlerTests
    {
        private GetAgenciesQueryHandler _testClass;
        private RofjaaDataContext _rofjaaDataContext;

        [SetUp]
        public void SetUp()
        {
            _rofjaaDataContext = new RofjaaDataContext();
            _testClass = new GetAgenciesQueryHandler(_rofjaaDataContext);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgenciesQueryHandler(_rofjaaDataContext);
            Assert.That(instance, Is.Not.Null);
        }
    }
}