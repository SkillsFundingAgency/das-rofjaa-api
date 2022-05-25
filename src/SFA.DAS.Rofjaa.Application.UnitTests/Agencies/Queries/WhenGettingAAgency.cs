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
    public class WhenGettingAAgency
    {
        [Test, MoqAutoData]
        public async Task Then_Gets_Agency_From_Service(
            GetAgencyQuery query,
            SFA.DAS.Rofjaa.Domain.Entities.Agency agencyFromService,
            [Frozen] Mock<IAgencyRepository> mockFrameworksService,
            GetAgencyQueryHandler handler)
        {
            mockFrameworksService
                .Setup(service => service.Get(query.LegalIdentityId))
                .ReturnsAsync(agencyFromService);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Should().BeEquivalentTo(agencyFromService);
        }
    }
}