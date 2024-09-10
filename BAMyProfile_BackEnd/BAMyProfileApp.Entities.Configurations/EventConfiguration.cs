using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

public class EventConfiguration: AuditableEntityTypeConfiguration<Event>
{
    public override void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.EventType).IsRequired();
		builder.HasMany(x => x.EventStudents).WithOne(x => x.Event).HasForeignKey(x => x.EventId);
		base.Configure(builder);
    }
}
