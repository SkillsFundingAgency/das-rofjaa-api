using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Domain.Interfaces
{
    public interface IAgencyService
    {
        Task<Agency> GetAgency(int agencyId);
        Task<IEnumerable<Agency>> GetAgencies();
    }
}
