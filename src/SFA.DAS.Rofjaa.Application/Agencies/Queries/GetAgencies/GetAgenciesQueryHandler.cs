using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Application.Common.DateTime;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies
{
    public class GetAgenciesQueryHandler : IRequestHandler<GetAgenciesQuery, GetAgenciesResult>
    {
        private readonly RofjaaDataContext _rofjaaDataContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public GetAgenciesQueryHandler(RofjaaDataContext rofjaaDataContext, IDateTimeProvider dateTimeProvider)
        {
            _rofjaaDataContext = rofjaaDataContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<GetAgenciesResult> Handle(GetAgenciesQuery request, CancellationToken cancellationToken)
        {
            var agenciesQuery = _rofjaaDataContext.Agency
                .AsQueryable();

            var agencies = await agenciesQuery
                .Where(x =>
                    x.EffectiveFrom <= _dateTimeProvider.GetNowUtc() &&
                    x.EffectiveTo == null || x.EffectiveTo >= _dateTimeProvider.GetNowUtc()
                )
                .OrderByDescending(x => x.Id)
                .Select(x => new GetAgenciesResult.Agency
                {
                    LegalEntityId = x.LegalEntityId,
                    IsGrantFunded = x.IsGrantFunded
                })
                .AsNoTracking()
                .AsSingleQuery()
                .ToListAsync(cancellationToken);

            var result = new GetAgenciesResult
            {
                Items = agencies
            };

            return result;
        }
    }
}
