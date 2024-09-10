using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAMyProfileApp.Entities.Configurations;

public class JobBenefitConfiguration : AuditableEntityTypeConfiguration<JobBenefit>
{
    public override void Configure(EntityTypeBuilder<JobBenefit> builder)
    {
        base.Configure(builder);

        builder.HasOne(jb => jb.Job)
            .WithMany(j => j.JobBenefits)
            .HasForeignKey(jb => jb.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(jb => jb.Benefit)
            .WithMany(b => b.JobBenefits)
            .HasForeignKey(jb => jb.BenefitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
