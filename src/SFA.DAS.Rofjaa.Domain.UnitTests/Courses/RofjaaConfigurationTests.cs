using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Domain.Configuration;

namespace SFA.DAS.Rofjaa.Domain.UnitTests.Courses;

[TestFixture]
public class RofjaaConfigurationTests
{
    private RofjaaConfiguration _testClass;

    [SetUp]
    public void SetUp() => _testClass = new RofjaaConfiguration();

    [Test]
    public void CanConstruct()
    {
        var instance = new RofjaaConfiguration();
        instance.Should().NotBeNull();
    }

    [Test]
    public void CanSetAndGetConnectionString()
    {
        const string testValue = "TestValue1713647412";
        _testClass.ConnectionString = testValue;
        testValue.Should().Be(_testClass.ConnectionString);
    }
}
