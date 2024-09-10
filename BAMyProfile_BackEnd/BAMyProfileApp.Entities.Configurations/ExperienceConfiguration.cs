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

namespace BAMyProfileApp.Entities.Configurations;

public class ExperienceConfiguration : AuditableEntityTypeConfiguration<Experience>
{
    public override void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.Property(x => x.CompanyName)
            .HasColumnType("NVARCHAR(100)")
            .IsRequired();
        builder.Property(x => x.DateOfStart)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(x => x.DateOfEnd)
            .HasColumnType("DATETIME");
        builder.Property(x => x.Position)
            .HasColumnType("NVARCHAR(50)")
            .IsRequired();
        builder.Property(x => x.Description)
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired();

        //Öğrenci ile bire çok ilişki tanımlanmıştır.Bir deneyim bir öğrenciye aittir.
        builder.HasOne(x => x.Student)
            .WithMany(x => x.Experience)
            .HasForeignKey(x => x.StudentId);

        base.Configure(builder);
    }
}
