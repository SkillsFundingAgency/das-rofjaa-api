namespace SFA.DAS.Rofjaa.Data.Tests.Repository
{
    using SFA.DAS.Rofjaa.Data.Repository;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using SFA.DAS.Rofjaa.Data;
    using System.Collections.Generic;
    using SFA.DAS.Rofjaa.Domain.Entities;
    using System.Threading.Tasks;

    [TestFixture]
    public class AgencyRepositoryTests
    {
        private AgencyRepository _testClass;
        private IRofjaaDataContext _rofjaaDataContext;

        [SetUp]
        public void SetUp()
        {
            _rofjaaDataContext = Substitute.For<IRofjaaDataContext>();
            _testClass = new AgencyRepository(_rofjaaDataContext);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new AgencyRepository(_rofjaaDataContext);
            Assert.That(instance, Is.Not.Null);
        }
    }
}