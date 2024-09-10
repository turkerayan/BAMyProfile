using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Core.Enums;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations
{
    public class StudentConfiguration : AuditableEntityTypeConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
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

            builder.HasIndex(x => x.Email).IsUnique();

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
            builder.Property(x => x.IsCandidate)
                    .IsRequired();

            // Tablo İlişkileri - Students-StudentsCertificates
            builder.HasMany(m => m.StudentCertificates)
                   .WithOne(o => o.Student)
                   .HasForeignKey(k => k.StudentId);

            // Tablo İlişkileri - Students-StudentsEvents
            builder.HasMany(x => x.StudentEvents).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            builder.HasMany(x => x.StudentCapabilities).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            builder.HasMany(s => s.StudentTrainingPrograms)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            //Student-Reference ilişkisi
            builder.HasMany(m => m.ReferenceStudents)
             .WithOne(o => o.Student)
             .HasForeignKey(k => k.StudentId);

            // Tablo İlişkileri - Students-StudentsLanguages
            builder.HasMany(x => x.StudentLanguages).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);

            builder.HasMany(x => x.StudentDepartments).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);


            base.Configure(builder);
        }
    }
}

