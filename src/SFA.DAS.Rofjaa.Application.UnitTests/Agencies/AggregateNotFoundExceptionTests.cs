using SFA.DAS.Rofjaa.Application.Abstractions.CustomExceptions;
using T = System.String;
using System;
using NUnit.Framework;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Abstractions.CustomExceptions
{
    [TestFixture]
    public class AggregateNotFoundException_1Tests
    {
        private AggregateNotFoundException<T> _testClass;
        private long _id;

        [SetUp]
        public void SetUp()
        {
            _id = 2007051974L;
            _testClass = new AggregateNotFoundException<T>(_id);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new AggregateNotFoundException<T>(_id);
            Assert.That(instance, Is.Not.Null);
        }
    }
}