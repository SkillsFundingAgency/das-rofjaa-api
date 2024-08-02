using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Application.UnitTests.DataFixture;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgencies;

[TestFixture]
public class GetAgenciesQueryHandlerTests : RofjaaDbContextFixture
{
    private Mock<IDateTimeProvider> _dateTimeProvider;

    [SetUp]
    public async Task Setup()
    {
        var agencies = new List<Agency> { new() { LegalEntityId = 1, IsGrantFunded = false }, new() { LegalEntityId = 2, IsGrantFunded = false } };

        await DbContext.Agency.AddRangeAsync(agencies);
        await DbContext.SaveChangesAsync();
    }

    [Test]
    public async Task Handle_Agencies_Pulled()
    {
        _dateTimeProvider = new Mock<IDateTimeProvider>();

        var getAgenciesQueryHandler = new GetAgenciesQueryHandler(DbContext, _dateTimeProvider.Object);

        var getAgenciesQuery = new GetAgenciesQuery();

        // Act
        var result = await getAgenciesQueryHandler.Handle(getAgenciesQuery, CancellationToken.None);
        var actualAgencies = result.Items.ToArray();

        // Assert
        var expectedAgenciesRecords = await DbContext.Agency.ToListAsync();

        expectedAgenciesRecords.Count.Should().Be(actualAgencies.Length);
    }
}
