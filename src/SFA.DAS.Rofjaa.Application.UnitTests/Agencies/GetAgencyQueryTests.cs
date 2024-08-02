using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies;

[TestFixture]
public class GetAgencyQueryTests
{
    private GetAgencyQuery _testClass;

    [SetUp]
    public void SetUp()
    {
        _testClass = new GetAgencyQuery();
    }

    [Test]
    public void CanConstruct()
    {
        var instance = new GetAgencyQuery();
        instance.Should().NotBeNull();
    }

    [Test]
    public void CanSetAndGetLegalEntityId()
    {
        const long testValue = 612008439;
        _testClass.LegalEntityId = testValue;
        testValue.Should().Be(_testClass.LegalEntityId);
    }
}
