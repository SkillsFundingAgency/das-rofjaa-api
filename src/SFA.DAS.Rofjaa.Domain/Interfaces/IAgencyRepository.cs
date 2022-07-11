using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Domain.Interfaces
{
    public interface IAgencyRepository
    {
        Task<Agency> Get(long id);
        Task<IEnumerable<Agency>> GetAll();
    }
}