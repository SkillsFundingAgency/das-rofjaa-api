using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Rofjaa.Domain.Entities;
using SFA.DAS.Rofjaa.Domain.Interfaces;

namespace SFA.DAS.Rofjaa.Data.Repository
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly IFjaaDataContext _fjaaDataContext;

        public AgencyRepository(IFjaaDataContext fjaaDataContext)
        {
            _fjaaDataContext = fjaaDataContext;
        }

        public async Task InsertMany(IEnumerable<Agency> agencies)
        {
            await _fjaaDataContext.Agency.AddRangeAsync(agencies);
            _fjaaDataContext.SaveChanges();
        }

        public void DeleteAll()
        {
            _fjaaDataContext.Agency.RemoveRange(_fjaaDataContext.Agency);
            _fjaaDataContext.SaveChanges();
        }

        public async Task<Agency> Get(int id)
        {
            var agency = await _fjaaDataContext
                .Agency
                .SingleOrDefaultAsync(c=>c.LegalIdentityId.Equals(id));
            return agency;
        }

        public async Task<IEnumerable<Agency>> GetAll()
        {
            var agencies = await _fjaaDataContext
                .Agency
                .ToListAsync();

            return agencies;
        }
    }
}
