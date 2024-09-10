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
    public class ApplicationConfiguration: AuditableEntityTypeConfiguration<Application>
    {
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(x => x.ApplicationStatus).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(500).HasColumnType("varchar");
            builder.Property(x => x.ApplicationDate).IsRequired().HasColumnType("DATETIME");

            //Tablo İlişkileri; Candidate-Job-ApplicationInterview

            builder.HasOne(x=>x.Candidate).WithMany(x=>x.Applications).HasForeignKey(x=>x.CandidateId);
            builder.HasOne(x=>x.Job).WithMany(x=>x.Applications).HasForeignKey(x=>x.JobId);

            base.Configure(builder);
        }
    }
}
