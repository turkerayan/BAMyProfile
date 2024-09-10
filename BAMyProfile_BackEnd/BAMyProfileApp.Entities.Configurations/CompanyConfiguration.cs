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
    public class CompanyConfiguration : AuditableEntityTypeConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Location).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Sector).IsRequired().HasMaxLength(50);
            builder.Property(c => c.GeneralInformation).IsRequired().HasMaxLength(200);

            builder.HasMany(c => c.CompanyContactInformations)
                   .WithOne(ci => ci.Company)
                   .HasForeignKey(ci => ci.CompanyId);

            base.Configure(builder);
        }
    }
}
