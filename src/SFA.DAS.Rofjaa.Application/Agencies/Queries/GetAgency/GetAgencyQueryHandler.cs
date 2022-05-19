using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFA.DAS.Rofjaa.Domain.Interfaces;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency
{
    public class GetAgencyQueryHandler : IRequestHandler<GetAgencyQuery,GetAgencyResult>
    {
        private readonly IAgencyService _agencyService;

        public GetAgencyQueryHandler (IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }
        public async Task<GetAgencyResult> Handle(GetAgencyQuery request, CancellationToken cancellationToken)
        {
            var agency = await _agencyService.GetAgency(request.LegalIdentityId);
            
            return new GetAgencyResult
            {
                Agency = agency
            };
        }
    }
}
