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

public class TrainingProgramConfiguration : AuditableEntityTypeConfiguration<TrainingProgram>
{
    public override void Configure(EntityTypeBuilder<TrainingProgram> builder)
    {
        builder.Property(x => x.Name)
               .HasColumnType("nvarchar(50)")
               .IsRequired();
        builder.Property(x => x.TimeInHours)
               .HasColumnType("int")
               .IsRequired();
        builder.Property(x => x.Content)
               .HasColumnType("nvarchar(500)")
               .IsRequired();

        builder.HasMany(t => t.StudentTrainingPrograms)
            .WithOne(t => t.TrainingProgram)
            .HasForeignKey(t => t.TrainingProgramId);

        base.Configure(builder);
    }
}
