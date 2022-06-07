using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies
{
    public class GetAgenciesQueryHandler : IRequestHandler<GetAgenciesQuery, GetAgenciesResult>
    {
        private readonly RofjaaDataContext _rofjaaDataContext;

        public GetAgenciesQueryHandler(RofjaaDataContext rofjaaDataContext)
        {
            _rofjaaDataContext = rofjaaDataContext;
        }

        public async Task<GetAgenciesResult> Handle(GetAgenciesQuery request, CancellationToken cancellationToken)
        {
            var agenciesQuery = _rofjaaDataContext.Agency
                .AsQueryable();

            var agencies = await agenciesQuery
                .Select(x => new GetAgenciesResult.Agency
                {
                    LegalIdentityId = x.LegalIdentityId,
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
