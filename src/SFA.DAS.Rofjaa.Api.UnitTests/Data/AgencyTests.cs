namespace SFA.DAS.Rofjaa.Data.Tests.Configuration
{
    using SFA.DAS.Rofjaa.Data.Configuration;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Metadata;
    using SFA.DAS.Rofjaa.Domain.Entities;
    using NSubstitute.Extensions;

    [TestFixture]
    public class AgencyTests
    {
        private Application.Agencies.Queries.GetAgencies.GetAgenciesResult.Agency _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Application.Agencies.Queries.GetAgencies.GetAgenciesResult.Agency();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new Application.Agencies.Queries.GetAgencies.GetAgenciesResult.Agency();
            Assert.That(instance, Is.Not.Null);
        }


    }
}