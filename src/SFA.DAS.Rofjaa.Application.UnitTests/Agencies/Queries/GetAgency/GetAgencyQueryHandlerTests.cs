using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Application.UnitTests.DataFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries.GetAgency;

public class GetAgencyQueryHandlerTests : RofjaaDbContextFixture
{
    private Mock<IDateTimeProvider> _dateTimeProvider;

    [Test]
    public async Task Individual_Agency_Not_Found_Null_Returned()
    {
        await PopulateDbContext();
        _dateTimeProvider = new Mock<IDateTimeProvider>();

        var getAgencyQueryHandler = new GetAgencyQueryHandler(DbContext, _dateTimeProvider.Object);

        var getAgencyQuery = new GetAgencyQuery
        {
            LegalEntityId = -1,
        };

        // Act
        var result = await getAgencyQueryHandler.Handle(getAgencyQuery, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    private async Task PopulateDbContext()
    {
        var agencies = new List<Domain.Entities.Agency> { new() { LegalEntityId = 1, IsGrantFunded = false }, new() { LegalEntityId = 2, IsGrantFunded = false } };
        await DbContext.Agency.AddRangeAsync(agencies);
        await DbContext.SaveChangesAsync();
    }
}
