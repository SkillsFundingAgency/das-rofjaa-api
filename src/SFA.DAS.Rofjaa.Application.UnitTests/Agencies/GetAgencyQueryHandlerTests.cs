namespace SFA.DAS.Rofjaa.Application.Tests.Agencies.Queries.GetAgency
{
    using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
    using System;
    using NUnit.Framework;
    using SFA.DAS.Rofjaa.Data;
    using System.Threading;
    using System.Threading.Tasks;

    [TestFixture]
    public class GetAgencyQueryHandlerTests
    {
        private GetAgencyQueryHandler _testClass;
        private RofjaaDataContext _rofjaaDataContext;

        [SetUp]
        public void SetUp()
        {
            _rofjaaDataContext = new RofjaaDataContext();
            _testClass = new GetAgencyQueryHandler(_rofjaaDataContext);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new GetAgencyQueryHandler(_rofjaaDataContext);
            Assert.That(instance, Is.Not.Null);
        }
    }
}