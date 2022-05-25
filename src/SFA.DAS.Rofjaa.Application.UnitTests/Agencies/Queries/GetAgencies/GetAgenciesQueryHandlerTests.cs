using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;
using SFA.DAS.Rofjaa.UnitTests.DataFixture;
using static SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies.GetAgenciesResult;

namespace SFA.DAS.Rofjaa.UnitTests.Application.Queries.GetPledges
{
    [TestFixture]
    public class GetAgenciesQueryHandlerTests : RofjaaDbContextFixture
    {
        private Fixture _fixture;

        [SetUp]
        public async Task Setup()
        {
            _fixture = new Fixture();

            var agencies = new List<Domain.Entities.Agency>();

            agencies.Add(new Domain.Entities.Agency() { LegalIdentityId = 1, Grant = false });
            agencies.Add(new Domain.Entities.Agency() { LegalIdentityId = 2, Grant = false });

            await DbContext.Agency.AddRangeAsync(agencies);
            await DbContext.SaveChangesAsync();
        }

        [Test]
        public async Task Handle_Agencies_Pulled()
        {
            var firstAgency = await DbContext.Agency.FirstAsync();

            var getAgenciesQueryHandler = new GetAgenciesQueryHandler(DbContext);

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
