using System.Collections.Generic;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Application.Agencies.Queries.GetAgencies
{
    public class GetAgencyResult
    {
        public IEnumerable<Agency> Agency { get; set; }
    }
}
