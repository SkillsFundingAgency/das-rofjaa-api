using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data.UnitTests.DatabaseMock;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Data.UnitTests.Repository.AgencyRepository
{
    public class WhenGettingAllItems
    {
        private List<Agency> _agencies;  
        private Mock<IFjaaDataContext> _fjaaDataContext;
        private Data.Repository.AgencyRepository _agencyRepository;

        [SetUp]
        public void Arrange()
        {
            _agencies = new List<Agency>
            {
                new Agency
                {
                    LegalIdentityId = 1
                },
                new Agency
                {
                    LegalIdentityId = 2
                }
            };

            _fjaaDataContext = new Mock<IFjaaDataContext>();
            _fjaaDataContext.Setup(x => x.Agency).ReturnsDbSet(_agencies);

            _agencyRepository = new Data.Repository.AgencyRepository(_fjaaDataContext.Object);
        }

        [Test]
        public async Task Then_The_Agency_Items_Are_Returned()
        {
            //Act
            var agencyImport = await _agencyRepository.GetAll();
            
            //Assert
            Assert.IsNotNull(agencyImport);
            agencyImport.Should().BeEquivalentTo(_agencies);
        }
    }
}