using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAMyProfileApp.Entities.Configurations;

public class CertificateConfiguration : AuditableEntityTypeConfiguration<Certificate>
{
    public override void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.Property(x => x.Name)
               .HasMaxLength(maxLength: 256)
               .IsRequired();

        builder.Property(x => x.CertificateDate).IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(maxLength: 256)
               .IsRequired();

        builder.Property(x => x.File).IsRequired();
           


        // Tablo İlişkileri - Certificates-StudentsCertificates
        builder.HasMany(m => m.CertificateStudents)
               .WithOne(o => o.Certificate)
               .HasForeignKey(k => k.CertificateId);

        base.Configure(builder);
    }
}
