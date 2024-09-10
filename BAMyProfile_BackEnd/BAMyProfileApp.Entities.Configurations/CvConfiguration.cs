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
/// <summary>
/// Cv entity'si için veritabanı konfigürasyonlarını tanımlar.
/// </summary>
public class CvConfiguration : AuditableEntityTypeConfiguration<Cv>
{/// <summary>
 /// Cv entity'si için EF Core tarafından sağlanan konfigürasyonları uygular.
 /// </summary>
 /// <param name="builder">EntityFramework EntityTypeBuilder nesnesi.</param>
    public override void Configure(EntityTypeBuilder<Cv> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Profile).IsRequired();

        // Cv ve Student arasındaki ilişkiyi belirtin (Bire Çok)
        builder.HasOne(c => c.Student)
            .WithMany(s => s.Cvs)
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
