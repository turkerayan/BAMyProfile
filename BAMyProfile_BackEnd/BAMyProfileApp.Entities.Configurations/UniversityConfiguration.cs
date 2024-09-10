using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations;

/// <summary>
/// <see cref="AuditableEntityTypeConfiguration{TEntity}"/> sınıfını kullanarak <see cref="University"/> 
/// entity tipinin veritabanı konfigürasyonlarını yapar.
/// </summary>
public class UniversityConfiguration : AuditableEntityTypeConfiguration<University>
{
    /// <summary>
    /// <see cref="University"/> entity tipi için veritabanı konfigürasyonlarını belirtir.
    /// Özellikle üniversite adı zorunlu olacak şekilde bir property konfigürasyonu ve 
    /// üniversite ile fakülteler arasındaki ilişkiyi tanımlayan ilişki konfigürasyonları eklenmiştir.
    /// </summary>
    /// <param name="builder">Entity tipi için konfigürasyon yapısını temsil eden <see cref="EntityTypeBuilder{TEntity}"/>.</param>
    public override void Configure(EntityTypeBuilder<University> builder)
    {
        // Üniversite adı özelliğini zorunlu olarak ayarlar.
        builder.Property(u => u.Name).IsRequired();

        // Üniversite ve fakülte arasındaki ilişkiyi belirtir.
        builder.HasMany(u => u.Faculties)
               .WithOne(f => f.University)
               .HasForeignKey(f => f.UniversityId);

        // Üst sınıftaki genel konfigürasyonları çağırır.
        base.Configure(builder);
    }
}
