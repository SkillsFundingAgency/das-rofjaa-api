using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.Domain.Entities;
using SFA.DAS.Rofjaa.Domain.Interfaces;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Queries
{
    public class WhenGettingAgencies
    {
        [Test, MoqAutoData]
        public async Task Then_Gets_Agencies_From_Service(
            GetAgenciesQuery query,
            List<SFA.DAS.Rofjaa.Domain.Entities.Agency> agencyFromService,
            [Frozen] Mock<IAgencyService> mockFrameworksService,
            GetAgenciesQueryHandler handler)
        {
            mockFrameworksService
                .Setup(service => service.GetAgencies())
                .ReturnsAsync(agencyFromService);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Agency.Should().BeEquivalentTo(agencyFromService);
        }
    }
}