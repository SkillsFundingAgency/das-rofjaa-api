using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.ApiResponses;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Api;

[TestFixture]
public class GetAgencyResponseTests
{
    private GetAgencyResponse _testClass;

    [SetUp]
    public void SetUp()
    {
        _testClass = new GetAgencyResponse();
    }

    [Test]
    public void CanConstruct()
    {
        var instance = new GetAgencyResponse();
        instance.Should().NotBeNull();
    }

    [Test]
    public void CanSetAndGetLegalEntityId()
    {
        const long testValue = 1806481352;
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
