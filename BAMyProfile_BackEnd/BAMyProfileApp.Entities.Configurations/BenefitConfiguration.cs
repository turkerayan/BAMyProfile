using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAMyProfileApp.Entities.Configurations;

public class BenefitConfiguration : AuditableEntityTypeConfiguration<Benefit>
{
    public override void Configure(EntityTypeBuilder<Benefit> builder)
    {
        base.Configure(builder);
        builder.Property(b => b.Name).IsRequired();
    }
}
