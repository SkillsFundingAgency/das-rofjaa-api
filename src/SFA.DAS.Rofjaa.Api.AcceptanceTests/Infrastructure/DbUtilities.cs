using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Rofjaa.Data;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Api.AcceptanceTests.Infrastructure;

public static class DbUtilities
{
    public static void LoadTestData(RofjaaDataContext context)
    {
        if (context.Agency.Any())
        {
            return;
        }

        var agencies = GetAgencies();
        context.Agency.AddRange(agencies);
        context.SaveChanges();
    }

    public static void ClearTestData(RofjaaDataContext context)
    {
        context.Agency.RemoveRange(context.Agency.ToList());
        context.SaveChanges();
    }

    public static IEnumerable<Agency> GetAgencies()
    {
        return new List<Agency> { new() { LegalEntityId = 1, IsGrantFunded = true }, new() { LegalEntityId = 2, IsGrantFunded = false }, };
    }

    public static Agency GetAgency(long id)
    {
        return GetAgencies().FirstOrDefault(c => c.LegalEntityId.Equals(id));
    }
}
