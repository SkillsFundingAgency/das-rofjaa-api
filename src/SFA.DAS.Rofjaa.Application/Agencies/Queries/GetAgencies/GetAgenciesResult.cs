using SFA.DAS.Rofjaa.Application.Models;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies
{
    public class GetAgenciesResult : QueryResult<GetAgenciesResult.Agency>
    {
        public class Agency
        {
            public long LegalEntityId { get; set; }
            public bool IsGrantFunded { get; set; }
        }
    }
}
