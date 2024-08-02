using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;

public class GetAgenciesQueryHandler(
    RofjaaDataContext rofjaaDataContext,
    IDateTimeProvider dateTimeProvider)
    : IRequestHandler<GetAgenciesQuery, GetAgenciesResult>
{
    public async Task<GetAgenciesResult> Handle(GetAgenciesQuery request, CancellationToken cancellationToken)
    {
        var agenciesQuery = rofjaaDataContext.Agency
            .AsQueryable();

        var agencies = await agenciesQuery
            .Where(x =>
                x.EffectiveFrom <= dateTimeProvider.GetNowUtc() &&
                (x.EffectiveTo == null || x.EffectiveTo >= dateTimeProvider.GetNowUtc())
            )
            .OrderByDescending(x => x.CreatedDate)
            .Select(x => new GetAgenciesResult.Agency
            {
                LegalEntityId = x.LegalEntityId,
                IsGrantFunded = x.IsGrantFunded
            })
            .AsNoTracking()
            .AsSingleQuery()
            .ToListAsync(cancellationToken);

        return new GetAgenciesResult
        {
            Items = agencies
        };
    }
}
