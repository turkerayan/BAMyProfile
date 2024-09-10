using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

public class EventStudentConfiguration : AuditableEntityTypeConfiguration<EventStudent>
{
	public override void Configure(EntityTypeBuilder<EventStudent> builder)
	{
		builder.Property(x => x.EventId)
			.IsRequired();
		builder.Property(x => x.StudentId)
		.IsRequired();
		base.Configure(builder);
	}
}
