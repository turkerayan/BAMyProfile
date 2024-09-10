using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

public class ReferenceStudentConfiguration : AuditableEntityTypeConfiguration<ReferenceStudent>
{
    public override void Configure(EntityTypeBuilder<ReferenceStudent> builder)
    {
        builder.Property(x => x.ReferenceId).IsRequired();
        builder.Property(x=>x.StudentId).IsRequired();  
        base.Configure(builder);
    }
}
