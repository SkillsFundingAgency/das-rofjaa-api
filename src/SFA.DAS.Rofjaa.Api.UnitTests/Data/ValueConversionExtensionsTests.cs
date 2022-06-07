namespace SFA.DAS.Rofjaa.Data.Tests.Extensions
{
    using SFA.DAS.Rofjaa.Data.Extensions;
    using T = System.String;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Metadata;

    [TestFixture]
    public static class ValueConversionExtensionsTests
    {
        [Test]
        public static void CanCallHasJsonConversion()
        {
            var propertyBuilder = new PropertyBuilder<T>(Substitute.For<IMutableProperty>());
            var result = propertyBuilder.HasJsonConversion<T>();
            Assert.Fail("Create or modify test");
        }

        [Test]
        public static void CannotCallHasJsonConversionWithNullPropertyBuilder()
        {
            Assert.Throws<ArgumentNullException>(() => default(PropertyBuilder<T>).HasJsonConversion<T>());
        }
    }
}