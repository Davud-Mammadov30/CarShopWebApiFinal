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
    public class AccountDetailConfiguration : IEntityTypeConfiguration<AccountDetail>
    {
        public void Configure(EntityTypeBuilder<AccountDetail> builder)
        {
            // Set the primary key
            builder.HasKey(ad => ad.Id);

            // Configure properties
            builder.Property(ad => ad.Code)
                .IsRequired()
                .HasMaxLength(20); // Adjust the length based on your requirements

            builder.Property(ad => ad.Money)
                .HasPrecision(18, 2); // Set the precision and scale for the decimal column

            // Configure relationships
            builder.HasOne(ad => ad.Customers)
                .WithMany(c => c.AccountDetails)
                .HasForeignKey(ad => ad.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            // Additional configuration as needed
        }
    }
}
