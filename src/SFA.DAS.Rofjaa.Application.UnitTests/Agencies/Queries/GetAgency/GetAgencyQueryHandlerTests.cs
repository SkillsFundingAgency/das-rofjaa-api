using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Application.UnitTests.DataFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Queries.GetAgency
{
    public class GetAgencyQueryHandlerTests : RofjaaDbContextFixture
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public async Task Handle_Individual_Agency_Not_Found_Null_Returned()
        {
            await PopulateDbContext();

            var getAgencyQueryHandler = new GetAgencyQueryHandler(DbContext);

            var getAgencyQuery = new GetAgencyQuery()
            {
                LegalEntityId = -1,
            };

            // Act
            var result = await getAgencyQueryHandler.Handle(getAgencyQuery, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

        protected async Task PopulateDbContext()
        {
            var agencies = new List<Domain.Entities.Agency>();

            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 1, IsGrantFunded = false });
            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 2, IsGrantFunded = false });

            await DbContext.Agency.AddRangeAsync(agencies);

            await DbContext.SaveChangesAsync();

        }
    }
}
