using System.Collections.Generic;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;

namespace SFA.DAS.Rofjaa.Api.ApiResponses
{
    public class GetAgenciesResponse
    {
        public IEnumerable<Agency> Agencies { get; set; }

        public class Agency
        {
            public int LegalEntityId { get; set; }
            public bool IsGrantFunded { get; set; }

            public static implicit operator Agency(GetAgenciesResult.Agency agency)
            {
                return new Agency()
                {
                    LegalEntityId = agency.LegalEntityId,
                    IsGrantFunded = agency.IsGrantFunded
                };
            }
        }
    }
}