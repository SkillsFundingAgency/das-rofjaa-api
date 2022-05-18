using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Data.UnitTests.DatabaseMock;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Data.UnitTests.Repository.AgencyRepository
{
    public class WhenDeletingAllItems
    {
        private Mock<IFjaaDataContext> _fjaaDataContext;
        private List<Agency> _frameworks;
        private Data.Repository.AgencyRepository _frameworkRepository;

        [SetUp]
        public void Arrange()
        {
            _frameworks = new List<Agency>
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
            _fjaaDataContext.Setup(x => x.Agency).ReturnsDbSet(_frameworks);
            

            _frameworkRepository = new Data.Repository.AgencyRepository(_fjaaDataContext.Object);
        }

        [Test]
        public void Then_The_Frameworks_Are_Removed()
        {
            //Act
            _frameworkRepository.DeleteAll();

            //Assert
            _fjaaDataContext.Verify(x=>x.Agency.RemoveRange(_fjaaDataContext.Object.Agency), Times.Once);
            _fjaaDataContext.Verify(x=>x.SaveChanges(), Times.Once);
        }
    }
}