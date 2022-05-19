using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Api.ApiResponses;
using SFA.DAS.Rofjaa.Domain.Entities;

namespace SFA.DAS.Rofjaa.Api.UnitTests.Models
{
    public class WhenCastingToGetAgencyResponseFromDomainType
    {
        [Test, AutoData]
        public void Then_Maps_Fields_Appropriately(
            Agency source)
        {
            var response = (GetAgencyResponse)source;

            response.Should().BeEquivalentTo(source);
        }
    }
}