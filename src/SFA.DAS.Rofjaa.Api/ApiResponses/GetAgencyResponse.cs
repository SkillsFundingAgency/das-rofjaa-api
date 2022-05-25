using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Api.ApiResponses
{
    public class GetAgencyResponse
    {
        public int LegalIdentityId { get; set; }
        public bool Grant { get; set; }


        public static implicit operator GetAgencyResponse(GetAgencyResult source)
        {
            return new GetAgencyResponse
            {
                LegalIdentityId = source.LegalIdentityId,
                Grant = source.Grant
            };
        }
    }
}
