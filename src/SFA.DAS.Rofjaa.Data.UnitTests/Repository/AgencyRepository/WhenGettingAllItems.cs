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
        private Mock<IRofjaaDataContext> _rofjaaDataContext;
        private Data.Repository.AgencyRepository _agencyRepository;

        [SetUp]
        public void Arrange()
        {
            _agencies = new List<Agency>
            {
                new Agency
                {
                    LegalEntityId = 1
                },
                new Agency
                {
                    LegalEntityId = 2
                }
            };

            _rofjaaDataContext = new Mock<IRofjaaDataContext>();
            _rofjaaDataContext.Setup(x => x.Agency).ReturnsDbSet(_agencies);

            _agencyRepository = new Data.Repository.AgencyRepository(_rofjaaDataContext.Object);
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