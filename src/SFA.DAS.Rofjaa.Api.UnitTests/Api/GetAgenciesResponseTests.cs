using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.ApiResponses;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Api;

[TestFixture]
public class GetAgenciesResponseTests
{
    private GetAgenciesResponse _testClass;

    [SetUp]
    public void SetUp()
    {
        _testClass = new GetAgenciesResponse();
    }

    [Test]
    public void CanConstruct()
    {
        var instance = new GetAgenciesResponse();
        instance.Should().NotBeNull();
    }

    [Test]
    public void CanSetAndGetAgencies()
    {
        var testValue = new[] { new GetAgenciesResponse.Agency { LegalEntityId = 1423772741, IsGrantFunded = true }, new GetAgenciesResponse.Agency { LegalEntityId = 1436015291, IsGrantFunded = true }, new GetAgenciesResponse.Agency { LegalEntityId = 1706355305, IsGrantFunded = false } };
         _testClass.Agencies = testValue;
        testValue.Should().BeEquivalentTo(_testClass.Agencies);
    }
}
