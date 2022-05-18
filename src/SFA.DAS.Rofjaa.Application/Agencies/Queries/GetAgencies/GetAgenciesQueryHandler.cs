using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFA.DAS.Rofjaa.Domain.Interfaces;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies
{
    public class GetAgenciesQueryHandler : IRequestHandler<GetAgenciesQuery, GetAgencyResult>
    {
        private readonly IAgencyService _agencyService;

        public GetAgenciesQueryHandler (IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }
        
        public async Task<GetAgencyResult> Handle(GetAgenciesQuery request, CancellationToken cancellationToken)
        {
            var agencies = await _agencyService.GetAgencies();
            
            return new GetAgencyResult
            {
                Agency = agencies
            }; 
                
        }
    }
}
