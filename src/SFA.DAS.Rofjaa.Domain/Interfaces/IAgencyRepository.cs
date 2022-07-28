using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Domain.Interfaces
{
    public interface IAgencyRepository
    {
        Task<Agency> Get(long legalEntityId);
        Task<IEnumerable<Agency>> GetAll();
    }
}