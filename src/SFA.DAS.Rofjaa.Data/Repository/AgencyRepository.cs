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

        public async Task InsertMany(IEnumerable<Agency> agencies)
        {
            await _rofjaaDataContext.Agency.AddRangeAsync(agencies);
            _rofjaaDataContext.SaveChanges();
        }

        public void DeleteAll()
        {
            _rofjaaDataContext.Agency.RemoveRange(_rofjaaDataContext.Agency);
            _rofjaaDataContext.SaveChanges();
        }

        public async Task<Agency> Get(int id)
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
