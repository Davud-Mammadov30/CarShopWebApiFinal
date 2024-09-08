using CarShopWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Configurations
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            // Configuring the primary key
            builder.HasKey(c => c.Id);

            // Configuring properties with constraints
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Address)
                .HasMaxLength(200);

            builder.Property(c => c.City)
                .HasMaxLength(100);

            // Configuring relationships
            builder.HasOne(c => c.AppUser)
                .WithMany(u => u.Customers)
                .HasForeignKey(c => c.AppUserID)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior based on your needs

            builder.HasMany(c => c.AccountDetails)
                .WithOne(ad => ad.Customers)
                .HasForeignKey(ad => ad.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ContactTypes)
                .WithOne(ct => ct.Customers)
                .HasForeignKey(ct => ct.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customers)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
