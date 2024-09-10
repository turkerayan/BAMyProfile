using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations
{
	public class ApplicationInterviewerConfiguration : AuditableEntityTypeConfiguration<ApplicationInterviewer>
	{
		public override void Configure(EntityTypeBuilder<ApplicationInterviewer> builder)
		{
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30).HasColumnType("varchar");
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(30).HasColumnType("varchar");
			builder.Property(x => x.Email).IsRequired().HasColumnType("varchar");
			builder.Property(x => x.Gender).IsRequired().HasColumnType("varchar");
			builder.Property(x => x.DateOfBirth).IsRequired().HasMaxLength(15).HasColumnType("date");
			

			//Tablo İlişkileri- ApplicationInterviewer-ApplicationInterview
			builder.HasOne(x => x.ApplicationInterview).WithMany(x => x.Interviewers).HasForeignKey(x => x.ApplicationInterviewId);
			base.Configure(builder);
		}
	}
}
