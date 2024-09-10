using BAMyProfileApp.Core.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Entities.EntityTypeConfigurations
{
    public class BaseCapabilityEntityTypeConfiguration<TEntity> : AuditableEntityTypeConfiguration<TEntity> where TEntity : BaseCapabilities
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CapabilityName)
                       .HasMaxLength(maxLength: 256);
        }
    }
}
