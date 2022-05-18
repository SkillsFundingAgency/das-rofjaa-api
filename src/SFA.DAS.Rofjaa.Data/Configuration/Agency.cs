using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SFA.DAS.Rofjaa.Data.Configuration
{
    public class Agency : IEntityTypeConfiguration<Domain.Entities.Agency>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Agency> builder)
        {
            builder.ToTable("Agency");
            builder.HasKey(x=>x.LegalIdentityId);
            builder.Property(x => x.Grant).HasColumnName("Grant").HasColumnType("bit").IsRequired();
            builder.HasIndex(x => x.LegalIdentityId).IsUnique();
        }
    }
}
