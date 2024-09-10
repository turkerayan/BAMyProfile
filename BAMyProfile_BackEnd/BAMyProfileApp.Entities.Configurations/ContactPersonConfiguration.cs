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
    public class ContactPersonConfiguration : AuditableEntityTypeConfiguration<ContactPerson>
    {
       

        public override void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.Property(x=>x.PersonFullName).IsRequired().HasMaxLength(60).HasColumnType("NVARCHAR(60)");
           
            builder.Property(x=>x.PersonEmail).IsRequired().HasColumnType("NVARCHAR(40)");
            builder.Property(x=>x.PersonPhoneNumber).IsRequired().HasMaxLength(15).HasColumnType("NVARCHAR(15)");
           
            builder.Property(x => x.Position).IsRequired().HasMaxLength(60).HasColumnType("NVARCHAR(60)");
            builder.Property(x => x.Department).IsRequired().HasMaxLength(60).HasColumnType("NVARCHAR(60)");

            //Company-ContactPerson ilşiki

            builder.HasOne(x => x.Company)
                   .WithMany(x=>x.ContactPersons)
                   .HasForeignKey(x=>x.CompanyId);

           
            base.Configure(builder);
        }
    }
}
