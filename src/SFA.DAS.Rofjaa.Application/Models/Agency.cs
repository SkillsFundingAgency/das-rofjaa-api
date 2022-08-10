using System;

namespace SFA.DAS.Rofjaa.Application.Models
{
    public class Agency
    {
        public long LegalEntityId { get; set; }
        public bool IsGrantFunded { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}