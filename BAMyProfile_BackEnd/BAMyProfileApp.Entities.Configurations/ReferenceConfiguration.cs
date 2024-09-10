using BAMyProfileApp.Core.Entities.EntityTypeConfigurations;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Configurations
{
    public class ReferenceConfiguration : AuditableEntityTypeConfiguration<Reference>
    {
        /// <summary>
        /// <see cref="Reference"/> entity için veritabanı tablosu konfigürasyonu.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Reference> builder)
        {
            // Tablo adını belirtir.
            //builder.ToTable("References");
            // Primary key'i belirtir.
            //builder.HasKey(x => x.Id);
            // Name özelliği için zorunluluk ve maksimum uzunluk belirtir.
            builder.Property(x => x.Name)
                .IsRequired();

            // Company özelliği için maksimum uzunluk belirtir.
            //builder.Property(x => x.Company)
            //    .HasMaxLength(50);
            base.Configure(builder);

            //ilişkilere göre düzenlemeler getirilebilir.
        }
    }
}
