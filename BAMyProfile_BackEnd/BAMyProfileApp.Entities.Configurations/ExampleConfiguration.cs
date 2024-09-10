using BAMyProfileApp.Core.Entities.Base;
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
    public class ExampleConfiguration: AuditableEntityTypeConfiguration<Example>
    {
        public override void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.Property(x=>x.Name).IsRequired();
            base.Configure(builder);
        }
    }
}
