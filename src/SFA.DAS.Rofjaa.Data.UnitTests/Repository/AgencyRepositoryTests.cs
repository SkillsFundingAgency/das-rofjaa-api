using NSubstitute;
using NUnit.Framework;

namespace SFA.DAS.Rofjaa.Data.UnitTests
{
    [TestFixture]
    public class AgencyRepositoryTests
    {
        private Data.Repository.AgencyRepository _testClass;
        private IRofjaaDataContext _rofjaaDataContext;

        [SetUp]
        public void SetUp()
        {
            _rofjaaDataContext = Substitute.For<IRofjaaDataContext>();
            _testClass = new Data.Repository.AgencyRepository(_rofjaaDataContext);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new Data.Repository.AgencyRepository(_rofjaaDataContext);
            Assert.That(instance, Is.Not.Null);
        }
    }
}