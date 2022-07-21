using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using System;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data;
using System.Threading;
using System.Threading.Tasks;
using SFA.DAS.Rofjaa.Application.Common.DateTime;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgency
{
    [TestFixture]
    public class GetAgencyQueryHandlerTests
    {
        private GetAgencyQueryHandler _testClass;
        private RofjaaDataContext _rofjaaDataContext;
        private DateTimeProvider _dateTimeProvider;

        [SetUp]
        public void SetUp()
        {
            _rofjaaDataContext = new RofjaaDataContext();
            _testClass = new GetAgencyQueryHandler(_rofjaaDataContext, _dateTimeProvider);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgencyQueryHandler(_rofjaaDataContext, _dateTimeProvider);
            Assert.That(instance, Is.Not.Null);
        }
    }
}