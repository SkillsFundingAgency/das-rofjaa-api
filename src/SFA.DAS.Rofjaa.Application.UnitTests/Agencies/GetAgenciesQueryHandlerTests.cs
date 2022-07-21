using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using System;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data;
using System.Threading;
using System.Threading.Tasks;
using SFA.DAS.Rofjaa.Application.Common.DateTime;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgencies
{
    [TestFixture]
    public class GetAgenciesQueryHandlerTests
    {
        private GetAgenciesQueryHandler _testClass;
        private RofjaaDataContext _rofjaaDataContext;
        private DateTimeProvider _dateTimeProvider;

        [SetUp]
        public void SetUp()
        {
            _rofjaaDataContext = new RofjaaDataContext();
            _testClass = new GetAgenciesQueryHandler(_rofjaaDataContext, _dateTimeProvider);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgenciesQueryHandler(_rofjaaDataContext, _dateTimeProvider);
            Assert.That(instance, Is.Not.Null);
        }
    }
}