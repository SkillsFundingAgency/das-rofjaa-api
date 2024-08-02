using Newtonsoft.Json;

namespace SFA.DAS.Rofjaa.Domain.Types;

public class Agency
{
    [JsonProperty("LegalEntityId")]
    public long LegalEntityId { get; set; }

    [JsonProperty("IsGrantFunded")]
    public bool IsGrantFunded { get; set; }
        
}
