using System.Threading;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Domain.Interfaces;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agency.Queries
{
    public class WhenGettingAFramework
    {
        [Test, MoqAutoData]
        public async Task Then_Gets_Framework_From_Service(
            GetAgencyQuery query,
            SFA.DAS.Rofjaa.Domain.Entities.Agency agencyFromService,
            [Frozen] Mock<IAgencyService> mockFrameworksService,
            GetAgencyQueryHandler handler)
        {
            mockFrameworksService
                .Setup(service => service.GetAgency(query.LegalIdentityId))
                .ReturnsAsync(agencyFromService);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Agency.Should().BeEquivalentTo(agencyFromService);
        }
    }
}