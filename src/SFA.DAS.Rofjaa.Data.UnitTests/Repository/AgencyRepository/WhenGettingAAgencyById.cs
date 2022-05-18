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
        private Mock<IFjaaDataContext> _fjaaDataContext;
        private List<Agency> _agencies;
        private Data.Repository.AgencyRepository _agencyRepository;
        private const int ExpectedAgencyId = 1;

        [SetUp]
        public void Arrange()
        {
            _agencies = new List<Agency>
            {
                new Agency()
                {
                    LegalIdentityId = 2
                },
                new Agency
                {
                    LegalIdentityId = ExpectedAgencyId
                }
            };

            _fjaaDataContext = new Mock<IFjaaDataContext>();
            _fjaaDataContext.Setup(x => x.Agency).ReturnsDbSet(_agencies);

            _agencyRepository = new Data.Repository.AgencyRepository(_fjaaDataContext.Object);
        }

        [Test]
        public async Task Then_The_Agency_Is_Returned_By_Id()
        {
            //Act
            var agency = await _agencyRepository.Get(ExpectedAgencyId);
            
            //Assert
            Assert.IsNotNull(agency);
            agency.Should().BeEquivalentTo(_agencies.SingleOrDefault(c=>c.LegalIdentityId.Equals(ExpectedAgencyId)));
        }
    }
}
