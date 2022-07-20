using System;
using System.Collections.Generic;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies;

namespace SFA.DAS.Rofjaa.Api.ApiResponses
{
    public class GetAgenciesResponse
    {
        public IEnumerable<Agency> Agencies { get; set; }

        public class Agency
        {
            public long LegalEntityId { get; set; }
            public bool IsGrantFunded { get; set; }
            public DateTime EffectiveFrom { get; set; }
            public DateTime EffectiveTo { get; set; }
            public string RemovalReason { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime LastUpdatedDate { get; set; }

            public static implicit operator Agency(GetAgenciesResult.Agency agency)
            {
                return new Agency()
                {
                    LegalEntityId = agency.LegalEntityId,
                    IsGrantFunded = agency.IsGrantFunded,
                    EffectiveFrom = agency.EffectiveFrom,
                    EffectiveTo = agency.EffectiveTo,
                    RemovalReason = agency.RemovalReason,
                    CreatedDate = agency.CreatedDate,
                    LastUpdatedDate = agency.LastUpdatedDate
                };
            }
        }
    }
}