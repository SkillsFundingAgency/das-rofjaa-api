namespace SFA.DAS.Rofjaa.Api.Tests
{
    using SFA.DAS.Rofjaa.Api;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public static class ProgramTests
    {
        [Test]
        public static void CanCallMain()
        {
            var args = new[] { "TestValue1209605962", "TestValue167201410", "TestValue1588194192" };
            Program.Main(args);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public static void CannotCallMainWithNullArgs()
        {
            Assert.Throws<ArgumentNullException>(() => Program.Main(default(string[])));
        }

        [Test]
        public static void CanCallCreateWebHostBuilder()
        {
            var args = new[] { "TestValue1876659881", "TestValue1130078816", "TestValue1249191768" };
            var result = Program.CreateWebHostBuilder(args);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public static void CannotCallCreateWebHostBuilderWithNullArgs()
        {
            Assert.Throws<ArgumentNullException>(() => Program.CreateWebHostBuilder(default(string[])));
        }
    }
}