using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations
{
	public class ApplicationInterviewConfiguration : AuditableEntityTypeConfiguration<ApplicationInterview>
	{
		public override void Configure(EntityTypeBuilder<ApplicationInterview> builder)
		{
			builder.Property(x => x.InterviewDate)
			.HasColumnType("DATETIME")
			.IsRequired();
            builder.Property(x => x.InterviewComment).IsRequired().HasMaxLength(500).HasColumnType("varchar");

            //Tablo İlişkileri -ApplicationInterview - Candidate - Company

			builder.HasOne(x => x.Company).WithMany(x => x.ApplicationInterviews).HasForeignKey(x => x.CompanyId);
		    builder.HasOne(x=>x.Application).WithOne(x=>x.ApplicationInterview).HasForeignKey<ApplicationInterview>(x => x.ApplicationId);
			builder.HasMany(m => m.Interviewers)
				   .WithOne(o => o.ApplicationInterview)
				   .HasForeignKey(k => k.ApplicationInterviewId);

			base.Configure(builder);
		}
	}
}
