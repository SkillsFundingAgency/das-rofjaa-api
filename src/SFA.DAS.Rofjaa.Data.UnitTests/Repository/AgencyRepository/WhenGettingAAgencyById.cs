using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data.UnitTests.DatabaseMock;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Data.UnitTests.Repository.AgencyRepository
{
    public class WhenGettingAAgencyById
    {
        private Mock<IRofjaaDataContext> _rofjaaDataContext;
        private List<Agency> _agencies;
        private Data.Repository.AgencyRepository _agencyRepository;
        private const long ExpectedAgencyId = 1;

        [SetUp]
        public void Arrange()
        {
            _agencies = new List<Agency>
            {
                new Agency()
                {
                    LegalEntityId = 2
                },
                new Agency
                {
                    LegalEntityId = ExpectedAgencyId
                }
            };

            _rofjaaDataContext = new Mock<IRofjaaDataContext>();
            _rofjaaDataContext.Setup(x => x.Agency).ReturnsDbSet(_agencies);

            _agencyRepository = new Data.Repository.AgencyRepository(_rofjaaDataContext.Object);
        }

        [Test]
        public async Task Then_The_Agency_Is_Returned_By_Id()
        {
            //Act
            var agency = await _agencyRepository.Get(ExpectedAgencyId);
            
            //Assert
            Assert.IsNotNull(agency);
            agency.Should().BeEquivalentTo(_agencies.SingleOrDefault(c=>c.LegalEntityId.Equals(ExpectedAgencyId)));
        }
    }
}
