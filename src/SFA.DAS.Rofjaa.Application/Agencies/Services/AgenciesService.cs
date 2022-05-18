using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFA.DAS.Rofjaa.Domain.Entities;
using SFA.DAS.Rofjaa.Domain.Interfaces;

namespace SFA.DAS.Rofjaa.Application.Agencies.Services
{
    public class AgenciesService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;

        public AgenciesService (IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;
        }
        public async Task<Agency> GetAgency(int agencyId)
        {
            var agency = await _agencyRepository.Get(agencyId);

            return agency;
        }

        public async Task<IEnumerable<Agency>> GetAgencies()
        {
            var agency = await _agencyRepository.GetAll();

            return agency.Select(c => c).ToList();
        }
    }
}
