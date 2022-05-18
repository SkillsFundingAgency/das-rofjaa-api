using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data.UnitTests.DatabaseMock;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Data.UnitTests.Repository.AgencyRepository
{
    public class WhenAddingMultipleItems
    {
        private Mock<IFjaaDataContext> _fjaaDataContext;
        private Data.Repository.AgencyRepository _agencyRepository;
        private List<Agency> _agencies;

        [SetUp]
        public void Arrange()
        {
            _agencies = new List<Agency>
            {
                new Agency
                {
                    LegalIdentityId = 1,
                    Grant = false
                },
                new Agency
                {
                    LegalIdentityId = 2,
                    Grant = true
                }
            };

            _fjaaDataContext = new Mock<IFjaaDataContext>();
            _fjaaDataContext.Setup(x => x.Agency).ReturnsDbSet(new List<Agency>());
            _agencyRepository = new Data.Repository.AgencyRepository(_fjaaDataContext.Object);
        }

        [Test]
        public async Task Then_The_Frameworks_Are_Added()
        {
            //Act
            await _agencyRepository.InsertMany(_agencies);

            //Assert
            _fjaaDataContext.Verify(x=>x.Agency.AddRangeAsync(_agencies, It.IsAny<CancellationToken>()), Times.Once);
            _fjaaDataContext.Verify(x=>x.SaveChanges(), Times.Once);
        }
    }
}