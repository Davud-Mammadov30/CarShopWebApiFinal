using CarShopWeb.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Set the primary key
            builder.HasKey(u => u.Id);

            // Configure properties
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50); // Set max length for FirstName

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50); // Set max length for LastName

            builder.Property(u => u.RefreshToken)
                .HasMaxLength(200); // Set max length for RefreshToken

            builder.Property(u => u.ExpiredDate)
                .IsRequired(); // ExpiredDate is required

            builder.Property(u => u.RefreshTokenEndTime)
                .IsRequired(); // RefreshTokenEndTime is required

            // Configure the relationship with Customers
            builder.HasMany(u => u.Customers)
                .WithOne(c => c.AppUser)
                .HasForeignKey(c => c.AppUserID)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior based on your needs

            // Additional configuration if needed
        }
    }
}
