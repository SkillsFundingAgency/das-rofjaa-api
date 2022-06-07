namespace SFA.DAS.Rofjaa.Data.Tests
{
    using SFA.DAS.Rofjaa.Data;
    using TContext = System.String;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using SFA.DAS.Rofjaa.Domain.Configuration;
    using Microsoft.Azure.Services.AppAuthentication;
    using SFA.DAS.Rofjaa.Domain.Entities;

    [TestFixture]
    public class RofjaaDataContextTests
    {
        private RofjaaDataContext _testClass;
        private DbContextOptions _options;
        private IOptions<RofjaaConfiguration> _config;
        private AzureServiceTokenProvider _azureServiceTokenProvider;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptions<TContext>();
            _config = Substitute.For<IOptions<RofjaaConfiguration>>();
            _azureServiceTokenProvider = new AzureServiceTokenProvider("TestValue2146420704", "TestValue739611845");
            _testClass = new RofjaaDataContext(_config, _options, _azureServiceTokenProvider);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new RofjaaDataContext();
            Assert.That(instance, Is.Not.Null);
            instance = new RofjaaDataContext(_options);
            Assert.That(instance, Is.Not.Null);
            instance = new RofjaaDataContext(_config, _options, _azureServiceTokenProvider);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullOptions()
        {
            Assert.Throws<ArgumentNullException>(() => new RofjaaDataContext(default(DbContextOptions)));
            Assert.Throws<ArgumentNullException>(() => new RofjaaDataContext(Substitute.For<IOptions<RofjaaConfiguration>>(), default(DbContextOptions), new AzureServiceTokenProvider("TestValue1542392629", "TestValue105314155")));
        }

        [Test]
        public void CannotConstructWithNullConfig()
        {
            Assert.Throws<ArgumentNullException>(() => new RofjaaDataContext(default(IOptions<RofjaaConfiguration>), new DbContextOptions<TContext>(), new AzureServiceTokenProvider("TestValue666059606", "TestValue1767908859")));
        }

        [Test]
        public void CannotConstructWithNullAzureServiceTokenProvider()
        {
            Assert.Throws<ArgumentNullException>(() => new RofjaaDataContext(Substitute.For<IOptions<RofjaaConfiguration>>(), new DbContextOptions<TContext>(), default(AzureServiceTokenProvider)));
        }

        [Test]
        public void CanSetAndGetAgency()
        {
            var testValue = new DbSet<Agency>();
            _testClass.Agency = testValue;
            Assert.That(_testClass.Agency, Is.EqualTo(testValue));
        }
    }
}