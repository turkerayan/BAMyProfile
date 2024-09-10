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
    public class EmployeeConfiguration : AuditableEntityTypeConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName).IsRequired()
                                              .HasMaxLength(30)
                                              .HasColumnType("varchar");

            builder.Property(e => e.LastName) .IsRequired()
                                              .HasMaxLength(30)
                                              .HasColumnType("varchar");

            builder.Property(e => e.Email)    .IsRequired()
                                              .HasColumnType("varchar");


            builder.Property(e => e.Gender)   .IsRequired()
                                              .HasColumnType("varchar");

            builder.Property(e => e.DateOfBirth).IsRequired()
                                                .HasMaxLength(15)
                                                .HasColumnType("date");

            builder.Property(e => e.IdentityId) .IsRequired()
                                                .HasMaxLength (11)
                                                .HasColumnType ("varchar");


            base.Configure(builder);
        }
    }
    
}
