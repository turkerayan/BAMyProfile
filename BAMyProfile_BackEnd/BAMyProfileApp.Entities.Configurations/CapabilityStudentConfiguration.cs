using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

public class CapabilityStudentConfiguration: AuditableEntityTypeConfiguration<CapabilityStudent>
{
    public override void Configure(EntityTypeBuilder<CapabilityStudent> builder)
    {
        builder.Property(x => x.CapabilityId).IsRequired();
        builder.Property(x => x.StudentId).IsRequired();
        base.Configure(builder);
    }
}
