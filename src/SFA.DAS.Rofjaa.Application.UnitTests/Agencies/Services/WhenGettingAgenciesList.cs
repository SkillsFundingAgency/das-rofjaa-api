using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Services;
using SFA.DAS.Rofjaa.Domain.Interfaces;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Agencies.Services
{
    public class WhenGettingAgenciesList
    {
        [Test, RecursiveMoqAutoData]
        public async Task Then_Gets_Agencies_From_Repository(
            List<Domain.Entities.Agency> agencyEntities,
            [Frozen] Mock<IAgencyRepository> sectorRepository,
            AgenciesService service)
        {
            sectorRepository
                .Setup(repository => repository.GetAll())
                .ReturnsAsync(agencyEntities);

            var agencies = (await service.GetAgencies()).ToList();

            agencies.Should().BeEquivalentTo(agencyEntities);

        }
    }
}