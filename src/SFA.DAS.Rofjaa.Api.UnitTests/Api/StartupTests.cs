namespace SFA.DAS.Rofjaa.Api.Tests
{
    using SFA.DAS.Rofjaa.Api;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;

    [TestFixture]
    public class StartupTests
    {
        private Startup _testClass;
        private IConfiguration _configuration;

        [SetUp]
        public void SetUp()
        {
            _configuration = Substitute.For<IConfiguration>();
            _testClass = new Startup(_configuration);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new Startup(_configuration);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullConfiguration()
        {
            Assert.Throws<ArgumentNullException>(() => new Startup(default(IConfiguration)));
        }

        [Test]
        public void CanCallConfigureServices()
        {
            var services = Substitute.For<IServiceCollection>();
            _testClass.ConfigureServices(services);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallConfigureServicesWithNullServices()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.ConfigureServices(default(IServiceCollection)));
        }

        [Test]
        public void CanCallConfigure()
        {
            var app = Substitute.For<IApplicationBuilder>();
            var env = Substitute.For<IWebHostEnvironment>();
            var logger = Substitute.For<ILogger<Startup>>();
            _testClass.Configure(app, env, logger);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallConfigureWithNullApp()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Configure(default(IApplicationBuilder), Substitute.For<IWebHostEnvironment>(), Substitute.For<ILogger<Startup>>()));
        }

        [Test]
        public void CannotCallConfigureWithNullEnv()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Configure(Substitute.For<IApplicationBuilder>(), default(IWebHostEnvironment), Substitute.For<ILogger<Startup>>()));
        }

        [Test]
        public void CannotCallConfigureWithNullLogger()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Configure(Substitute.For<IApplicationBuilder>(), Substitute.For<IWebHostEnvironment>(), default(ILogger<Startup>)));
        }
    }
}