using System.Collections.Generic;
using SFA.DAS.Rofjaa.Domain.Entities;
using SFA.DAS.Rofjaa.Application.Models;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies
{
    public class GetAgenciesResult : PagedQueryResult<GetAgenciesResult.Agency>
    {
        public class Agency
        {
            public int LegalIdentityId { get; set; }
            public bool Grant { get; set; }
        }
    }
}
