using BAMyProfileApp.Core.Entities.Base;
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
    public class CandidateConfiguration : AuditableEntityTypeConfiguration<Candidate>
    {
        public override void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x => x.FirstName)
                   .HasMaxLength(30)
                   .HasColumnType("nvarchar")
                   .IsRequired();

            builder.Property(x => x.LastName)
                   .HasMaxLength(30)
                   .HasColumnType("nvarchar")
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(50)
                   .HasColumnType("nvarchar")
                   .IsRequired();

            builder.Property(x => x.PhoneNumber)
                   .HasMaxLength(11)
                   .HasColumnType("nvarchar")
                   .IsRequired(false);

            builder.Property(x => x.Gender)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(x => x.DateOfBirth)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(x => x.Address)
                   .HasMaxLength(256)
                   .HasColumnType("nvarchar")
                   .IsRequired(false);

            //Tablo İlişkileri- Candidate-Student

            builder.HasOne(student=>student.Student)
                .WithOne()
                .HasForeignKey<Candidate>(candidate=>candidate.StudentId);


            //builder.Property(candidate => candidate.JobStatus).IsRequired();


            builder.ToTable("Candidates");

            base.Configure(builder);
        }
    }
}
