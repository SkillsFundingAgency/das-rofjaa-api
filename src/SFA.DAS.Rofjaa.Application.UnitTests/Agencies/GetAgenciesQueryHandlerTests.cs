using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using System;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data;
using System.Threading;
using System.Threading.Tasks;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using Moq;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgencies
{
    [TestFixture]
    public class GetAgenciesQueryHandlerTests
    {
        private GetAgenciesQueryHandler _testClass;
        private RofjaaDataContext _rofjaaDataContext;
        private Mock<IDateTimeProvider> _dateTimeProvider;

        [SetUp]
        public void SetUp()
        {
            _rofjaaDataContext = new RofjaaDataContext();
            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _testClass = new GetAgenciesQueryHandler(_rofjaaDataContext, _dateTimeProvider.Object);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgenciesQueryHandler(_rofjaaDataContext, _dateTimeProvider.Object);
            Assert.That(instance, Is.Not.Null);
        }
    }
}