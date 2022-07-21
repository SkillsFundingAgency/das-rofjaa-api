using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Application.UnitTests.DataFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Queries.GetAgencies
{
    [TestFixture]
    public class GetAgenciesQueryHandlerTests : RofjaaDbContextFixture
    {
        private Fixture _fixture;
        private Mock<IDateTimeProvider> _dateTimeProvider;


        [SetUp]
        public async Task Setup()
        {
            _fixture = new Fixture();

            var agencies = new List<Domain.Entities.Agency>();

            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 1, IsGrantFunded = false });
            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 2, IsGrantFunded = false });

            await DbContext.Agency.AddRangeAsync(agencies);
            await DbContext.SaveChangesAsync();
        }

        [Test]
        public async Task Handle_Agencies_Pulled()
        {
            var firstAgency = await DbContext.Agency.FirstAsync();
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            var getAgenciesQueryHandler = new GetAgenciesQueryHandler(DbContext, _dateTimeProvider.Object);

            var getAgenciesQuery = new GetAgenciesQuery();

            // Act
            var result = await getAgenciesQueryHandler.Handle(getAgenciesQuery, CancellationToken.None);
            var actualAgencies = result.Items.ToArray();

            // Assert
            var expectedAgenciesRecords = await DbContext.Agency.ToListAsync();

            Assert.AreEqual(expectedAgenciesRecords.Count(), actualAgencies.Count());
        }
    }

}
