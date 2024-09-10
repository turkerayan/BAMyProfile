using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

public class StudentTrainingProgramConfiguration : AuditableEntityTypeConfiguration<StudentTrainingProgram>
{
    public override void Configure(EntityTypeBuilder<StudentTrainingProgram> builder)
    {
        builder.Property(x => x.TrainingProgramId).IsRequired();
        builder.Property(x => x.StudentId).IsRequired();

        base.Configure(builder);
    }
}
