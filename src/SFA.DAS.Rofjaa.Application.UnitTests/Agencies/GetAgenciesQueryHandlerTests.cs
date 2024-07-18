using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies;

[TestFixture]
public class GetAgenciesQueryHandlerTests
{
    private RofjaaDataContext _rofjaaDataContext;
    private Mock<IDateTimeProvider> _dateTimeProvider;

    [SetUp]
    public void SetUp()
    {
        _rofjaaDataContext = new RofjaaDataContext();
        _dateTimeProvider = new Mock<IDateTimeProvider>();
    }

    [Test]
    public void CanConstruct()
    {
        var instance = new GetAgenciesQueryHandler(_rofjaaDataContext, _dateTimeProvider.Object);
        instance.Should().NotBeNull();
    }
}
