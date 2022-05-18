using System.Collections.Generic;

namespace SFA.DAS.Rofjaa.Api.ApiResponses
{
    public class GetAgenciesResponse
    {
        public IEnumerable<GetAgencyResponse> Agencies { get; set; }
    }
}