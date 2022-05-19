using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Services;
using SFA.DAS.Rofjaa.Domain.Interfaces;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agency.Services
{
    public class WhenGettingAAgency
    {
        [Test, RecursiveMoqAutoData]
        public async Task Then_Gets_A_Agency_From_The_Repository(
            int agencyId,
            SFA.DAS.Rofjaa.Domain.Entities.Agency agencyFromRepo,
            [Frozen] Mock<IAgencyRepository> mockStandardsRepository,
            AgenciesService service)
        {
            mockStandardsRepository
                .Setup(repository => repository.Get(agencyId))
                .ReturnsAsync(agencyFromRepo);

            var agency = await service.GetAgency(agencyId);

            agency.Should().BeEquivalentTo(agencyFromRepo);

        }
    }
}