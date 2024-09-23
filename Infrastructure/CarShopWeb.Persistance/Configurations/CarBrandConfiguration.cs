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
    public class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
    {
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            // Table name
            builder.ToTable("CarBrand");

            // Primary key
            builder.HasKey(cb => cb.Id);

            // Column constraints
            builder.Property(cb => cb.Name)
                .IsRequired()  // Name is required
                .HasMaxLength(100);  // Limit the length of the brand name

            // Relationships
            builder.HasMany(cb => cb.CarModels)  // One CarBrand has many CarModels
                .WithOne(cm => cm.CarBrand)  // Each CarModel has one CarBrand
                .HasForeignKey(cm => cm.CarBrandID)  // Foreign key in CarModel
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete behavior

            // Index on the Name column to ensure fast lookups and uniqueness
            builder.HasIndex(cb => cb.Name).IsUnique();
        }
    }
}
