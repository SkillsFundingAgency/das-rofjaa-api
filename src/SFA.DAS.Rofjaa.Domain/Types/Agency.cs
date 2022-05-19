using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SFA.DAS.Rofjaa.Domain.Types
{
    public class Agency
    {
        [JsonProperty("LegalIdentityId")]
        public int LegalIdentityId { get; set; }

        [JsonProperty("Grant")]
        public bool Grant { get; set; }
        
    }
}
