using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Application.UnitTests.DataFixture;

namespace SFA.DAS.Rofjaa.Application.UnitTests.Queries.GetAgency
{
    public class GetAgencyQueryHandlerTests : RofjaaDbContextFixture
    {
        private readonly Fixture _fixture = new Fixture();
        private Mock<IDateTimeProvider> _dateTimeProvider;

        [Test]
        public async Task Individual_Agency_Not_Found_Null_Returned()
        {
            await PopulateDbContext();
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            var getAgencyQueryHandler = new GetAgencyQueryHandler(DbContext, _dateTimeProvider.Object);

            var getAgencyQuery = new GetAgencyQuery()
            {
                LegalEntityId = -1,
            };

            // Act
            var result = await getAgencyQueryHandler.Handle(getAgencyQuery, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task Individual_Agency_Inside_Date_Is_Returned()
        {
            await PopulateDbContextInsideDates();
            int id = 1;
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            var getAgencyQueryHandler = new GetAgencyQueryHandler(DbContext, _dateTimeProvider.Object);

            var getAgencyQuery = new GetAgencyQuery()
            {
                LegalEntityId = 1
            };

            // Act
            var result = await getAgencyQueryHandler.Handle(getAgencyQuery, CancellationToken.None);

            // Assert
            Assert.AreEqual(result.LegalEntityId, id);
        }

        [Test]
        public async Task Individual_Agency_Outside_Date_Not_Returned()
        {
            await PopulateDbContextOutsideDates();
            int legalEntityId = 1;
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            var getAgencyQueryHandler = new GetAgencyQueryHandler(DbContext, _dateTimeProvider.Object);

            var getAgencyQuery = new GetAgencyQuery()
            {
                LegalEntityId = legalEntityId
            };

            // Act
            var result = await getAgencyQueryHandler.Handle(getAgencyQuery, CancellationToken.None);

            // Assert
            Assert.AreEqual(result.LegalEntityId, legalEntityId);
        }

        protected async Task PopulateDbContext()
        {
            var agencies = new List<Domain.Entities.Agency>();
            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 1, IsGrantFunded = false });
            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 2, IsGrantFunded = false });
            await DbContext.Agency.AddRangeAsync(agencies);
            await DbContext.SaveChangesAsync();
        }

        protected async Task PopulateDbContextInsideDates()
        {
            var agencies = new List<Domain.Entities.Agency>();
            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 1, IsGrantFunded = false, EffectiveFrom = new DateTime(2020, 01, 01) });
            await DbContext.Agency.AddRangeAsync(agencies);
            await DbContext.SaveChangesAsync();
        }

        protected async Task PopulateDbContextOutsideDates()
        {
            var agencies = new List<Domain.Entities.Agency>();
            agencies.Add(new Domain.Entities.Agency() { LegalEntityId = 1, IsGrantFunded = false, EffectiveFrom = new DateTime(2010, 01, 01) });
            await DbContext.Agency.AddRangeAsync(agencies);
            await DbContext.SaveChangesAsync();
        }

    }
}
