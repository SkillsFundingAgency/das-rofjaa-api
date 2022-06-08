using SFA.DAS.Rofjaa.Application.Models;
using T = System.String;
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Models
{
    [TestFixture]
    public class QueryResult_1Tests
    {
        private class TestQueryResult : QueryResult<T>
        {
        }

        private TestQueryResult _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new TestQueryResult();
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new TestQueryResult();
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanSetAndGetItems()
        {
            var testValue = new List<T>();
            _testClass.Items = testValue;
            Assert.That(_testClass.Items, Is.EqualTo(testValue));
        }
    }
}