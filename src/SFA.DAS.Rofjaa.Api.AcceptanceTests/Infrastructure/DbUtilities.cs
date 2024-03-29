﻿using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Rofjaa.Data;
using Agency = SFA.DAS.Rofjaa.Domain.Entities.Agency;

namespace SFA.DAS.Rofjaa.Api.AcceptanceTests.Infrastructure
{
    public static class DbUtilities
    {
        public static void LoadTestData(RofjaaDataContext context)
        {
            context.Agency.AddRange(GetAgencies());
            context.SaveChanges();
        }

        public static void ClearTestData(RofjaaDataContext context)
        {
            context.Agency.RemoveRange(context.Agency.ToList());
            context.SaveChanges();
        }

        public static IEnumerable<Agency> GetAgencies()
        {
            return new List<Agency>
            {
                new Agency
                {
                    LegalEntityId = 1,
                    IsGrantFunded = true
                },
                new Agency
                {
                    LegalEntityId = 2,
                    IsGrantFunded = false
                },
            };
        }

        public static Agency GetAgency(long id)
        {
            return GetAgencies().FirstOrDefault(c => c.LegalEntityId.Equals(id));
        }
    }
}