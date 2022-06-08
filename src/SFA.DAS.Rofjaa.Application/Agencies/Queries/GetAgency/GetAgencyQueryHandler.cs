using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Data;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency
{
    public class GetAgencyQueryHandler : IRequestHandler<GetAgencyQuery,GetAgencyResult>
    {
        private readonly RofjaaDataContext _rofjaaDataContext;

        public GetAgencyQueryHandler (RofjaaDataContext rofjaaDataContext)
        {
            _rofjaaDataContext = rofjaaDataContext;
        }
        public async Task<GetAgencyResult> Handle(GetAgencyQuery request, CancellationToken cancellationToken)
        {
            var agencyQuery = _rofjaaDataContext.Agency
                .Where(x => x.LegalEntityId == request.LegalEntityId)
                .AsQueryable();

            var agency = await agencyQuery.SingleOrDefaultAsync(cancellationToken: cancellationToken);

            var result = new GetAgencyResult
            {
                LegalEntityId = agency.LegalEntityId,
                IsGrantFunded = agency.IsGrantFunded
            };

            return result;
        }
    }
}
