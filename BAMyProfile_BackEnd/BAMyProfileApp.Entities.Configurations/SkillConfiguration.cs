using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAMyProfileApp.Entities.Configurations;

public class SkillConfiguration : AuditableEntityTypeConfiguration<Skill>
{
    public override void Configure(EntityTypeBuilder<Skill> builder)
    {
        base.Configure(builder);
        builder.Property(s => s.Name).IsRequired();
    }
}
