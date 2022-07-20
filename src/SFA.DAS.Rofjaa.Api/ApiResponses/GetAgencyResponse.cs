using System;
using SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Api.ApiResponses
{
    public class GetAgencyResponse
    {
        public long LegalEntityId { get; set; }
        public bool IsGrantFunded { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public string RemovalReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public static implicit operator GetAgencyResponse(GetAgencyResult source)
        {
            return new GetAgencyResponse
            {
                LegalEntityId = source.LegalEntityId,
                IsGrantFunded = source.IsGrantFunded,
                EffectiveFrom = source.EffectiveFrom,
                EffectiveTo = source.EffectiveTo,
                RemovalReason = source.RemovalReason,
                CreatedDate = source.CreatedDate,
                LastUpdatedDate = source.LastUpdatedDate
            };
        }
    }
}
