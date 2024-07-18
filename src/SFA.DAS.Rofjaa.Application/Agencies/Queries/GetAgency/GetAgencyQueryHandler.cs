using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;

public class GetAgencyQueryHandler(
    RofjaaDataContext rofjaaDataContext,
    IDateTimeProvider dateTimeProvider)
    : IRequestHandler<GetAgencyQuery, GetAgencyResult>
{
    public async Task<GetAgencyResult> Handle(GetAgencyQuery request, CancellationToken cancellationToken)
    {
        var agencyQuery = rofjaaDataContext.Agency
            .Where(x =>
                x.LegalEntityId == request.LegalEntityId &&
                x.EffectiveFrom <= dateTimeProvider.GetNowUtc() &&
                (x.EffectiveTo == null || x.EffectiveTo >= dateTimeProvider.GetNowUtc())
            )
            .OrderByDescending(x => x.CreatedDate)
            .AsQueryable();

        var agency = await agencyQuery.FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (agency == null)
        {
            return null;
        }

        return new GetAgencyResult
        {
            LegalEntityId = agency.LegalEntityId,
            IsGrantFunded = agency.IsGrantFunded
        };
    }
}
