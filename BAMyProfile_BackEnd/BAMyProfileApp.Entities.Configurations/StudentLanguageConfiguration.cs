using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations
{
    public class StudentLanguageConfiguration : AuditableEntityTypeConfiguration<StudentLanguage>
    {
        public override void Configure(EntityTypeBuilder<StudentLanguage> builder)
        {
            builder.Property(x => x.LanguageId)
                .IsRequired();
            builder.Property(x => x.StudentId)
            .IsRequired();
            base.Configure(builder);
        }
   
    }
}
