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
/// <see cref="AuditableEntityTypeConfiguration{TEntity}"/> sınıfını kullanarak <see cref="Department"/> 
/// entity tipinin veritabanı konfigürasyonlarını yapar.
/// </summary>
public class DepartmentConfiguration : AuditableEntityTypeConfiguration<Department>
{
    /// <summary>
    /// <see cref="Department"/> entity tipi için veritabanı konfigürasyonlarını belirtir.
    /// Bölüm adı özelliğini zorunlu olarak ayarlar.
    /// </summary>
    /// <param name="builder">Entity tipi için konfigürasyon yapısını temsil eden <see cref="EntityTypeBuilder{TEntity}"/>.</param>
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        // Bölüm adı özelliğini zorunlu olarak ayarlar.
        builder.Property(d => d.Name).IsRequired();
        builder.HasMany(x => x.DepartmentStudents).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
        // Üst sınıftaki genel konfigürasyonları çağırır.
        base.Configure(builder);
            
}
}
