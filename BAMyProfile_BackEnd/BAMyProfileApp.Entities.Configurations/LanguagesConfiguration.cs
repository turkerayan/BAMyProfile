using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

public class LanguagesConfiguration : AuditableEntityTypeConfiguration<Languages>
{
    public override void Configure(EntityTypeBuilder<Languages> builder)
    {
        builder.Property(x => x.LanguageName)
            .HasMaxLength(maxLength: 256)
            .IsRequired();
        builder.Property(x => x.Level)
               .IsRequired();

        // Tablo İlişkileri - Languages-StudentsLanguages
        builder.HasMany(x => x.LanguageStudents)
               .WithOne(x => x.Language)
               .HasForeignKey(x => x.LanguageId);
        
        base.Configure(builder);
    }
}
