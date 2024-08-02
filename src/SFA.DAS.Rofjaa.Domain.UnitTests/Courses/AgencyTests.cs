using FluentAssertions;
using NUnit.Framework;

namespace SFA.DAS.Rofjaa.Domain.UnitTests.Courses;

[TestFixture]
public class AgencyTests
{
    private Entities.Agency _testClass;

    [SetUp]
    public void SetUp() => _testClass = new Entities.Agency();

    [Test]
    public void CanConstruct()
    {
        var instance = new Entities.Agency();
        instance.Should().NotBeNull();
    }

    [Test]
    public void CanSetAndGetLegalEntityId()
    {
        const long testValue = 2089984886;
        _testClass.LegalEntityId = testValue;
        testValue.Should().Be(_testClass.LegalEntityId);
    }

    [Test]
    public void CanSetAndGetIsGrantFunded()
    {
        const bool testValue = true;
        _testClass.IsGrantFunded = testValue;
        testValue.Should().Be(_testClass.IsGrantFunded);
    }
}
