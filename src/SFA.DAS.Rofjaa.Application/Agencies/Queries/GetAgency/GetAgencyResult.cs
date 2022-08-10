using System;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgency
{
    public class GetAgencyResult
    {
        public long LegalEntityId { get; set; }
        public bool IsGrantFunded { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}