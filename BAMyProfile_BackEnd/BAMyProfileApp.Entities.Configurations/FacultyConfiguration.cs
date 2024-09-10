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
/// <see cref="AuditableEntityTypeConfiguration{TEntity}"/> sınıfını kullanarak <see cref="Faculty"/> 
/// entity tipinin veritabanı konfigürasyonlarını yapar.
/// </summary>
public class FacultyConfiguration : AuditableEntityTypeConfiguration<Faculty>
{
    /// <summary>
    /// <see cref="Faculty"/> entity tipi için veritabanı konfigürasyonlarını belirtir.
    /// Fakülte adı özelliğini zorunlu olarak ayarlar ve fakülte ile bölümler arasındaki ilişkiyi tanımlayan 
    /// ilişki konfigürasyonları eklenmiştir.
    /// </summary>
    /// <param name="builder">Entity tipi için konfigürasyon yapısını temsil eden <see cref="EntityTypeBuilder{TEntity}"/>.</param>
    public override void Configure(EntityTypeBuilder<Faculty> builder)
    {
        // Fakülte adı özelliğini zorunlu olarak ayarlar.
        builder.Property(f => f.Name).IsRequired();

        // Fakülte ve bölüm arasındaki ilişkiyi belirtir.
        builder.HasMany(f => f.Departments)
               .WithOne(d => d.Faculty)
               .HasForeignKey(d => d.FacultyId);

        // Üst sınıftaki genel konfigürasyonları çağırır.
        base.Configure(builder);
    }
}