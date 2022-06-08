using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.Rofjaa.Domain.Entities;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.Rofjaa.Domain.UnitTests.Courses
{
    public class WhenCastingToAgencyFromEntity
    {
        [Test, RecursiveMoqAutoData]
        public void Then_The_Fields_Are_Correctly_Mapped(Agency agency)
        {
            var actual = (Domain.Entities.Agency) agency;
            
            actual.Should().BeEquivalentTo(agency);
          
        }
    }
}