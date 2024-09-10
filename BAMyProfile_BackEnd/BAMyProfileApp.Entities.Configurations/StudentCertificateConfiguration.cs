using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAMyProfileApp.Entities.Configurations;

public class StudentCertificateConfiguration : AuditableEntityTypeConfiguration<StudentCertificate>
{
    public override void Configure(EntityTypeBuilder<StudentCertificate> builder)
    {
        builder.Property(x => x.CertificateId).IsRequired();
        builder.Property(x => x.StudentId).IsRequired();
        base.Configure(builder);
    }
}
