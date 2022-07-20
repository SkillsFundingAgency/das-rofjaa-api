using System;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Api.ApiResponses
{
    public class GetAgencyResponse
    {
        public long LegalEntityId { get; set; }
        public bool IsGrantFunded { get; set; }

        public static implicit operator GetAgencyResponse(GetAgencyResult source)
        {
            return new GetAgencyResponse
            {
                LegalEntityId = source.LegalEntityId,
                IsGrantFunded = source.IsGrantFunded
            };
        }
    }
}
