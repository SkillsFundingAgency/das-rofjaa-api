using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies;

[TestFixture]
public class GetAgenciesQueryTests
{
    [Test]
    public void CanConstruct()
    {
        var instance = new GetAgenciesQuery();
        instance.Should().NotBeNull();
    }
}
