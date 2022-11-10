using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency
{
    public class GetAgencyQueryHandler : IRequestHandler<GetAgencyQuery,GetAgencyResult>
    {
        private readonly RofjaaDataContext _rofjaaDataContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public GetAgencyQueryHandler (RofjaaDataContext rofjaaDataContext, IDateTimeProvider dateTimeProvider)
        {
            _rofjaaDataContext = rofjaaDataContext;
            _dateTimeProvider = dateTimeProvider;
        }
        public async Task<GetAgencyResult> Handle(GetAgencyQuery request, CancellationToken cancellationToken)
        {
            var agencyQuery = _rofjaaDataContext.Agency
                .Where(x =>
                    x.LegalEntityId == request.LegalEntityId &&
                    x.EffectiveFrom <= _dateTimeProvider.GetNowUtc() &&
                    (x.EffectiveTo == null || x.EffectiveTo >= _dateTimeProvider.GetNowUtc())
                )
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();

            var agency = await agencyQuery.FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (agency == null)
            {
                return null;
            }

            var result = new GetAgencyResult
            {
                LegalEntityId = agency.LegalEntityId,
                IsGrantFunded = agency.IsGrantFunded
            };

            return result;
        }
    }
}
