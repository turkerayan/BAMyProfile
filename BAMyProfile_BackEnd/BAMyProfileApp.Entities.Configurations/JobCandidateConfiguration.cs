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
    public class JobCandidateConfiguration : AuditableEntityTypeConfiguration<JobCandidate>
    {
        public override void Configure(EntityTypeBuilder<JobCandidate> builder)
        {
            base.Configure(builder);

          builder.HasOne(jb => jb.Job)
         .WithMany(j => j.JobCandidate)
         .HasForeignKey(jb => jb.JobId)
         .OnDelete(DeleteBehavior.Restrict);

           builder.HasOne(jb => jb.Candidate)
         .WithMany(b => b.JobCandidate)
         .HasForeignKey(jb => jb.CandidateID)
         .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
