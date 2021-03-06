using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Domain.Entities;
using SFA.DAS.Rofjaa.Domain.Interfaces;

namespace SFA.DAS.Rofjaa.Data.Repository
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly IRofjaaDataContext _rofjaaDataContext;

        public AgencyRepository(IRofjaaDataContext rofjaaDataContext)
        {
            _rofjaaDataContext = rofjaaDataContext;
        }

        public async Task<Agency> Get(long id)
        {
            var agency = await _rofjaaDataContext
                .Agency
                .SingleOrDefaultAsync(c=>c.LegalEntityId.Equals(id));
            return agency;
        }

        public async Task<IEnumerable<Agency>> GetAll()
        {
            var agencies = await _rofjaaDataContext
                .Agency
                .ToListAsync();

            return agencies;
        }
    }
}
