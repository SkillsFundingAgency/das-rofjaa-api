using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Models;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies;

[TestFixture]
public class AgencyTests
{
    private Agency _testClass;

    [SetUp]
    public void SetUp() => _testClass = new Agency();

    [Test]
    public void CanConstruct()
    {
        var instance = new Agency();
        Assert.That(instance, Is.Not.Null);
    }

    [Test]
    public void CanSetAndGetLegalEntityId()
    {
        const long testValue = 43691550;
        _testClass.LegalEntityId = testValue;
        testValue.Should().Be(_testClass.LegalEntityId);
    }

    [Test]
    public void CanSetAndGetIsGrantFunded()
    {
        const bool testValue = false;
        _testClass.IsGrantFunded = testValue;
        testValue.Should().Be(_testClass.IsGrantFunded);
    }
}
