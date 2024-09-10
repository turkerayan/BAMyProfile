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
    public class CompanyContactInformationConfiguration : AuditableEntityTypeConfiguration<CompanyContactInformation>
    {
        public override void Configure(EntityTypeBuilder<CompanyContactInformation> builder)
        {
            builder.Property(ci => ci.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(ci => ci.Email).IsRequired().HasMaxLength(140);
            builder.Property(ci => ci.Address).IsRequired().HasMaxLength(200);

            base.Configure(builder);
        }
    }
}
