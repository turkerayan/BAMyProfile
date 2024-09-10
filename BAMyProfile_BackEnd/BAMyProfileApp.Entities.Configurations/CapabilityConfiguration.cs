using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

public class CapabilityConfiguration : AuditableEntityTypeConfiguration<Capability>
{
    public override void Configure(EntityTypeBuilder<Capability> builder)
    {
        builder.Property(x => x.CapabilityName)
            .HasMaxLength(maxLength: 256)
            .IsRequired();

        builder.HasMany(x=>x.CapabilityStudents).WithOne(x=>x.Capability).HasForeignKey(x=>x.CapabilityId);

        base.Configure(builder);
    }
}
