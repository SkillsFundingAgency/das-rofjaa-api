using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies;

[TestFixture]
public class GetAgencyResultTests
{
    private GetAgencyResult _testClass;

    [SetUp]
    public void SetUp() => _testClass = new GetAgencyResult();

    [Test]
    public void CanConstruct()
    {
        var instance = new GetAgencyResult();
        instance.Should().NotBeNull();
    }

    [Test]
    public void CanSetAndGetLegalEntityId()
    {
        const long testValue = 505870637;
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
