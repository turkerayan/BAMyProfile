using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAMyProfileApp.Entities.Configurations;

public class JobSkillConfiguration : AuditableEntityTypeConfiguration<JobSkill>
{
    public override void Configure(EntityTypeBuilder<JobSkill> builder)
    {
        base.Configure(builder);
        
        builder
            .HasOne(js => js.Job)
            .WithMany(j => j.JobSkills)
            .HasForeignKey(js => js.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(js => js.Skill)
            .WithMany(s => s.JobSkills)
            .HasForeignKey(js => js.SkillId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}