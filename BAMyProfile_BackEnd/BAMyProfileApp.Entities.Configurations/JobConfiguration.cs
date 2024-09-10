using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAMyProfileApp.Entities.Configurations;

public class JobConfiguration : AuditableEntityTypeConfiguration<Job>
{
    public override void Configure(EntityTypeBuilder<Job> builder)
    {
        base.Configure(builder);
        builder.Property(j => j.Position).IsRequired();
        builder.Property(j => j.Description).IsRequired();
        builder.Property(j => j.Experience).IsRequired();
        builder.Property(j => j.Education).IsRequired();
        builder.Property(j => j.Salary).IsRequired();
        builder.Property(j => j.WorkLocation).IsRequired();
        builder.Property(j => j.JobStatus).IsRequired();
    }
}
